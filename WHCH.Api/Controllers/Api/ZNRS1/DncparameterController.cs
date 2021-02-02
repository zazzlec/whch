
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
using WHCH.Api.RequestPayload.Rbac.Parameter;
using WHCH.Api.ViewModels.Rbac.Dncparameter;
using System.Transactions;
using System.Collections.Generic;
using WHCH.Api.Utils;
using MySql.Data.MySqlClient;

namespace WHCH.Api.Controllers.Api.WHCH1
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/WHCH1/[controller]/[action]")]
    [ApiController]
    //[CustomAuthorize]
    public class DncparameterController : ControllerBase
    {
        private readonly WHCHDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造control
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public DncparameterController(WHCHDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult List()
        {
            using (_dbContext)
            {
                var list = _dbContext.Dncparameter.ToList();
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
        public IActionResult List(DncparameterRequestPayload payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                var query = _dbContext.Dncparameter.AsQueryable();
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
                
                if (payload.FirstSort != null)
                {
                    query = query.OrderBy(payload.FirstSort.Field, payload.FirstSort.Direct == "DESC");
                }
                var list = query.Paged(payload.CurrentPage, payload.PageSize).ToList();
                var totalCount = query.Count();
                var data = list.Select(_mapper.Map< Dncparameter, DncparameterJsonModel>);

                response.SetData(data, totalCount);
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
        public IActionResult Create(DncparameterCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var entity = _mapper.Map< DncparameterCreateViewModel, Dncparameter>(model);
                if (string.IsNullOrEmpty(model.DncBoiler_Name))
                {
                    entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == "无");
                    entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                }
                else
                {
                    entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncBoiler_Name);
                    entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                }
                entity.Status = CommonEnum.Status.Normal;
                _dbContext.Dncparameter.Add(entity);
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
                var entity = _dbContext.Dncparameter.FirstOrDefault(x => x.Id ==  int.Parse(code));
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map< Dncparameter, DncparameterCreateViewModel>(entity));
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
        public IActionResult Edit(DncparameterEditViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {


                var entity = _dbContext.Dncparameter.FirstOrDefault(x => x.Id == model.Id);





                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.DncBoiler_Name = model.DncBoiler_Name;
                entity.Airpress = model.Airpress;
                entity.Drybulbtemp = model.Drybulbtemp;
                entity.Wetbulbtemp = model.Wetbulbtemp;
                entity.Watertemp3 = model.Watertemp3;
                entity.Flyashratio = model.Flyashratio;
                entity.Slagratio = model.Slagratio;
                entity.Temp0cp = model.Temp0cp;
                entity.Temp100cp = model.Temp100cp;
                entity.Temp200cp = model.Temp200cp;
                entity.Temp0ch = model.Temp0ch;
                entity.Temp100ch = model.Temp100ch;
                entity.Temp200ch = model.Temp200ch;
                entity.Specificheat = model.Specificheat;
                entity.Heatloss = model.Heatloss;
                entity.Airheat = model.Airheat;
                entity.Design_in_wind_temp = model.Design_in_wind_temp;

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
                    
                    var sql1= string.Format("delete from  Dncparameter  WHERE id IN ({0}) and IsDeleted=1", parameterNames);
                    _dbContext.Database.ExecuteSqlCommand(sql1);
                    
                    var sql = string.Format("UPDATE Dncparameter SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
                    parameters.Add(new MySqlParameter("@IsDeleted", (int)isDeleted));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }else{
                    var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    
                    var sql1= string.Format("delete from  Dncparameter  WHERE id IN ({0}) and IsDeleted=1", parameterNames);
                    _dbContext.Database.ExecuteSqlCommand(sql1);
                    
                    var sql = string.Format("UPDATE Dncparameter SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
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
                    var sql = string.Format("UPDATE Dncparameter SET Status=@Status WHERE id IN ({0})", parameterNames);
                    parameters.Add(new MySqlParameter("@Status", (int)status));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }else{
                    var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dncparameter SET Status=@Status WHERE id IN ({0})", parameterNames);
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
                        KeyValuePair<string, List< DncparameterCreateViewModel>> res = ValidateJson.Validation< DncparameterCreateViewModel>(fsts);

                        if (res.Key.Equals("ok"))
                        {
                            List< DncparameterCreateViewModel> arr = res.Value;
                            foreach ( DncparameterCreateViewModel item in arr)
                            {

      
                                
                                
                                
                                
                                
                                
                                var entity = _mapper.Map< DncparameterCreateViewModel, Dncparameter>(item);
                                
                                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == item.DncBoiler_Name);
                                
                                entity.Status = CommonEnum.Status.Normal;
                                _dbContext.Dncparameter.Add(entity);
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









