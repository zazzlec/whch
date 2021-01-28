
using System;
using System.Data.SqlClient;
using System.Linq;
using AutoMapper;
using WHCH.Api.Entities;
using WHCH.Api.Entities.Enums;
using WHCH.Api.Extensions;
using WHCH.Api.Extensions.AuthContext;
using WHCH.Api.Extensions.CustomException;
using WHCH.Api.Extensions.DataAccess;
using WHCH.Api.Models.Response;
using WHCH.Api.RequestPayload.Rbac.Role;
using WHCH.Api.Utils;
using WHCH.Api.ViewModels.Rbac.DncRole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WHCH.Api.RequestPayload.Rbac.Gwfspointdata;
using WHCH.Api.ViewModels.Rbac.Dncgwfspointdata;
using System.Transactions;
using System.Collections.Generic;
using WHCH.Api.Utils;
using MySql.Data.MySqlClient;
using LitJson;

namespace WHCH.Api.Controllers.Api.WHCH1
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/WHCH1/[controller]/[action]")]
    [ApiController]
    //[CustomAuthorize]
    public class DncgwfspointdataController : ControllerBase
    {
        private readonly WHCHDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造control
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public DncgwfspointdataController(WHCHDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult List()
        {
            using (_dbContext)
            {
                var list = _dbContext.Dncgwfspointdata.ToList();
                list = list.FindAll(x => x.IsDeleted != CommonEnum.IsDeleted.Yes );
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(list);
                return Ok(response);
            }
        }
        /// <summary>
        /// 查询请求
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult List(DncgwfspointdataRequestPayload payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            try
            {
                using (_dbContext)
                {
                    var query = _dbContext.Dncgwfspointdata.AsQueryable();
                    //模糊查询

                    //是否删除，是否启用
                    if (payload.IsDeleted > CommonEnum.IsDeleted.All)
                    {
                        query = query.Where(x => x.IsDeleted == payload.IsDeleted);
                    }
                    if (payload.Status > CommonEnum.Status.All)
                    {
                        query = query.Where(x => x.Status == payload.Status);
                    }
                    if (payload.boilerid != -1)
                    {
                        query = query.Where(x => x.DncBoilerId == payload.boilerid);
                    }
                    if (!string.IsNullOrEmpty(payload.d1) && !string.IsNullOrEmpty(payload.d2))
                    {
                        var btime = DateTime.Parse(payload.d1);
                        var etime = DateTime.Parse(payload.d2);
                        query = query.Where(x => x.RealTime.Value >= btime && x.RealTime.Value <= etime);
                    }
                    if (!string.IsNullOrEmpty(payload.nid))
                    {
                        query = query.Where(x => x.NameId_Val == int.Parse(payload.nid));
                    }
                    if (payload.FirstSort != null)
                    {
                        query = query.OrderBy(payload.FirstSort.Field, payload.FirstSort.Direct == "DESC");
                    }
                    var list = query.Paged(payload.CurrentPage, payload.PageSize).ToList();
                    var totalCount = query.Count();
                    var data = list.Select(_mapper.Map<Dncgwfspointdata, DncgwfspointdataJsonModel>);

                    response.SetData(data, totalCount);
                    return Ok(response);
                }
            }
            catch (Exception fff)
            {
                response.SetError(fff.Message);
                return Ok(response);
            }
            
        }



        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult BatchOk(string fsts)
        {
            var response = ResponseModelFactory.CreateInstance;

            try
            {
                using (_dbContext)
                {
                    var sql = "UPDATE dncgwfspointdata SET CheckTime=NOW(),CheckPerson='" + AuthContextService.CurrentUser.DisplayName + "' WHERE id = " + fsts + "";
                    _dbContext.Database.ExecuteSqlCommand(sql);

                }
                response.SetSuccess();
                return Ok(response);
            }
            catch (Exception cc)
            {
                response.SetError();
                return Ok(response);
            }

        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="fsts"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Reset(Dncgwfspointdata fsts)
        {
            var response = ResponseModelFactory.CreateInstance;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (_dbContext)
                    {
                        var guid = AuthContextService.CurrentUser.Guid;
                        var user = _dbContext.DncUser.FirstOrDefaultAsync(x => x.Guid == guid).Result;

                        Dncboiler db = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == fsts.DncBoiler_Name);


                        Dncgwfspoint data = _dbContext.Dncgwfspoint.FirstOrDefault(x => x.DncBoilerId == db.Id && x.NameId_Val == fsts.NameId_Val);
                        data.Slblife = 100;
                        data.Fsrisk = 0;
                        data.Fstime = 0;
                        data.Last_fire_time_sum = 0;
                        _dbContext.SaveChanges();


                        Dncgwfspointreset entity = new Dncgwfspointreset();

                        entity.DncBoiler = db;
                        entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                        entity.DncBoilerId = entity.DncBoiler.Id;
                        entity.DncGwfspoint = data;
                        entity.DncGwfspointId = data.Id;
                        entity.IsDeleted = 0;
                        entity.OperatePerson = user.DisplayName;
                        entity.RealTime = DateTime.Now;
                        entity.Remarks = "";
                        entity.BoilerStatus = entity.DncBoiler.NowStatus;


                        entity.Status = CommonEnum.Status.Normal;
                        _dbContext.Dncgwfspointreset.Add(entity);
                        _dbContext.SaveChanges();
                    }

                    scope.Complete();
                }
                response.SetSuccess();
                return Ok(response);
            }
            catch (Exception cc)
            {
                response.SetError();
                return Ok(response);
            }

        }



        /// <summary>
        /// 基础工况调整
        /// </summary>
        /// <param name="fsts"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult ChangeBaseAgle(String fsts)
        {
            var response = ResponseModelFactory.CreateInstance;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (_dbContext)
                    {
                        var guid = AuthContextService.CurrentUser.Guid;
                        var user = _dbContext.DncUser.FirstOrDefaultAsync(x => x.Guid == guid).Result;

                        

                        JsonData jsonData = JsonMapper.ToObject(fsts);
                        String bid = jsonData["bid"].ToString().Replace("\"", "");

                        var bolid = _dbContext.Dncboiler.FirstOrDefault(x => x.Id == int.Parse(bid));


                        JsonData arr = jsonData["arr"];
                        for (int j = 0; j < arr.Count; j++)
                        {
                            JsonData info = arr[j];
                            String id= info["id"].ToString().Replace("\"", "");
                            String fmkd = info["fmkd"].ToString().Replace("\"", "");
                            String ltmj = info["ltmj"].ToString().Replace("\"", "");
                            String bfb = info["bfb"].ToString().Replace("\"", "");

                            //Dncwind 更新
                            Dncwind d =_dbContext.Dncwind.FirstOrDefault(x => x.Id == int.Parse(id));
                            d.Base_angle = int.Parse(fmkd);
                            d.Base_ltmj = double.Parse(ltmj);
                            d.Base_percent = double.Parse(bfb);
                            _dbContext.SaveChanges();

                            //Dncwindbase 记录
                            Dncwindbase base1 = new Dncwindbase();
                            base1.Base_angle= int.Parse(fmkd);
                            base1.Base_percent = double.Parse(bfb);
                            base1.DncBoiler = bolid;
                            base1.DncBoilerId = bolid.Id;
                            base1.DncBoiler_Name = bolid.K_Name_kw;
                            base1.DncWind = d;
                            base1.DncWindId = d.Id;
                            base1.DncWind_Name = d.Wind_Name_kw;
                            base1.IsDeleted = CommonEnum.IsDeleted.No;
                            base1.OpeartePerson = user.DisplayName;
                            base1.RealTime = DateTime.Now;
                            base1.Remarks = "";
                            base1.Status = CommonEnum.Status.Normal;

                            _dbContext.Dncwindbase.Add(base1);
                            _dbContext.SaveChanges();
                        }

                        JsonData arr2 = jsonData["grp"];
                        for (int j = 0; j < arr2.Count; j++)
                        {
                            JsonData info = arr2[j];
                            String n = info["n"].ToString().Replace("\"", "");
                            String p = info["p"].ToString().Replace("\"", "");

                            Dncwindgroup gp= _dbContext.Dncwindgroup.FirstOrDefault(x => x.DncBoilerId == int.Parse(bid) && x.Group_Name_kw == n );
                            gp.Base_percent = double.Parse(p);

                            _dbContext.SaveChanges();
                        }
                    }

                    scope.Complete();
                }
                response.SetSuccess();
                return Ok(response);
            }
            catch (Exception cc)
            {
                response.SetError();
                return Ok(response);
            }

        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(DncgwfspointdataCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var entity = _mapper.Map< DncgwfspointdataCreateViewModel, Dncgwfspointdata>(model);

                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.Status = CommonEnum.Status.Normal;
                _dbContext.Dncgwfspointdata.Add(entity);
                _dbContext.SaveChanges();

                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 编辑页获取实体
        /// </summary>
        /// <param name="code">惟一编码</param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(string code)
        {
            using (_dbContext)
            {
                var entity = _dbContext.Dncgwfspointdata.FirstOrDefault(x => x.Id ==  int.Parse(code));
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map< Dncgwfspointdata, DncgwfspointdataCreateViewModel>(entity));
                return Ok(response);
            }
        }

        /// <summary>
        /// 保存编辑后的信息
        /// </summary>
        /// <param name="model">视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(DncgwfspointdataEditViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {


                var entity = _dbContext.Dncgwfspointdata.FirstOrDefault(x => x.Id == model.Id);





    
                entity.RealTime = model.RealTime;
                entity.H2s = model.H2s;
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.DncBoiler_Name = model.DncBoiler_Name;
                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;
                entity.Advice = model.Advice;
                entity.CheckTime = model.CheckTime;
                entity.CheckPerson = model.CheckPerson;

                _dbContext.SaveChanges();
                return Ok(response);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(string ids)
        {
            var response = ResponseModelFactory.CreateInstance;

            response = UpdateIsDelete(CommonEnum.IsDeleted.Yes, ids);
            return Ok(response);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="ids">ID字符串,多个以逗号隔开</param>
        /// <returns></returns>
        private ResponseModel UpdateIsDelete(CommonEnum.IsDeleted isDeleted, string ids)
        {
            using (_dbContext)
            {
                if (ToolService.DbType.Equals("mysql")){
                    var parameters = ids.Split(",").Select((id, index) => new MySqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dncgwfspointdata SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
                    parameters.Add(new MySqlParameter("@IsDeleted", (int)isDeleted));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }else{
                    var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dncgwfspointdata SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
                    parameters.Add(new SqlParameter("@IsDeleted", (int)isDeleted));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }
                
            }
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="ids">ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Recover(string ids)
        {
            var response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
            return Ok(response);
        }
        
        
        /// <summary>
        /// 批量更新状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="ids">ID字符串,多个以逗号隔开</param>
        /// <returns></returns>
        private ResponseModel UpdateStatus(UserStatus status, string ids)
        {
            using (_dbContext)
            {
                if (ToolService.DbType.Equals("mysql")){
                    var parameters = ids.Split(",").Select((id, index) => new MySqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dncgwfspointdata SET Status=@Status WHERE id IN ({0})", parameterNames);
                    parameters.Add(new MySqlParameter("@Status", (int)status));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }else{
                    var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dncgwfspointdata SET Status=@Status WHERE id IN ({0})", parameterNames);
                    parameters.Add(new SqlParameter("@Status", (int)status));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }
                
            }
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ids">ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Batch(string command, string ids)
        {
            var response = ResponseModelFactory.CreateInstance;
            switch (command)
            {
                case "delete":
                    response = UpdateIsDelete(CommonEnum.IsDeleted.Yes, ids);
                    break;
                case "recover":
                    response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
                    break;
                case "forbidden":
                    response = UpdateStatus(UserStatus.Forbidden, ids);
                    break;
                case "normal":
                    response = UpdateStatus(UserStatus.Normal, ids);
                    break;
                default:
                    break;
            }
            return Ok(response);
        }


        
        

        /// <summary>
        /// 批量创建
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult BatchCreate(string fsts)
        {
            var response = ResponseModelFactory.CreateInstance;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (_dbContext)
                    {
                        KeyValuePair<string, List< DncgwfspointdataCreateViewModel>> res = ValidateJson.Validation< DncgwfspointdataCreateViewModel>(fsts);

                        if (res.Key.Equals("ok"))
                        {
                            List< DncgwfspointdataCreateViewModel> arr = res.Value;
                            foreach ( DncgwfspointdataCreateViewModel item in arr)
                            {

      
                                
                                
                                
                                
                                
                                
                                var entity = _mapper.Map< DncgwfspointdataCreateViewModel, Dncgwfspointdata>(item);
                                
                                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == item.DncBoiler_Name);
                                
                                entity.Status = CommonEnum.Status.Normal;
                                _dbContext.Dncgwfspointdata.Add(entity);
                            }
                        }
                        else
                        {
                            response.SetFailed(res.Key + " 数据格式有误.");
                            return Ok(response);
                        }
                        _dbContext.SaveChanges();
                    }
                    // 如果所有的操作都执行成功，则Complete()会被调用来提交事务
                    // 如果发生异常，则不会调用它并回滚事务
                    scope.Complete();
                }
                response.SetSuccess();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.SetFailed(ex.Message);
                return Ok(response);
            }
        }
        

    }
}









