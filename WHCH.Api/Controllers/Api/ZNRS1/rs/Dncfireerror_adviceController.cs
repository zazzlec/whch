
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
using WHCH.Api.RequestPayload.Rbac.Fireerror_advice;
using WHCH.Api.ViewModels.Rbac.Dncfireerror_advice;
using System.Transactions;
using System.Collections.Generic;
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
    public class Dncfireerror_adviceController : ControllerBase
    {
        private readonly WHCHDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造control
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public Dncfireerror_adviceController(WHCHDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult List()
        {
            using (_dbContext)
            {
                var list = _dbContext.Dncfireerror_advice.ToList();
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
        public IActionResult List(Dncfireerror_adviceRequestPayload payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                var query = _dbContext.Dncfireerror_advice.AsQueryable();
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
                if (!string.IsNullOrEmpty(payload.boilertime))
                {
                    query = query.Where(x => x.RealTime.Value.ToString("yyyy-MM-dd HH:mm:ss") == payload.boilertime);
                }
                if (payload.boilerid != -1)
                {
                    query = query.Where(x => x.DncBoilerId == payload.boilerid);
                }

                if (!string.IsNullOrEmpty(payload.t))
                {
                    //沾污系数,建议
                    if (payload.t.Equals("1"))
                    {
                        query = query.Where(x => x.DncTypeId >= 103 && x.DncTypeId<=108);
                    }
                    else if (payload.t.Equals("2"))
                    {
                        query = query.Where(x => x.DncTypeId < 103 || x.DncTypeId == 112);
                    }
                }


                if (payload.FirstSort != null)
                {
                    query = query.OrderBy(payload.FirstSort.Field, payload.FirstSort.Direct == "DESC");
                }
                var list = query.Paged(payload.CurrentPage, payload.PageSize).ToList();
                var totalCount = query.Count();
                var data = list.Select(_mapper.Map< Dncfireerror_advice, Dncfireerror_adviceJsonModel>);

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
        public IActionResult Create(Dncfireerror_adviceCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var entity = _mapper.Map< Dncfireerror_adviceCreateViewModel, Dncfireerror_advice>(model);
                entity.DncType = _dbContext.Dnctype.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncType_Name);
                entity.DncType_Name = entity.DncType.K_Name_kw;
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.Status = CommonEnum.Status.Normal;
                _dbContext.Dncfireerror_advice.Add(entity);
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
                var entity = _dbContext.Dncfireerror_advice.FirstOrDefault(x => (x.Id+"") == code);
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map< Dncfireerror_advice, Dncfireerror_adviceCreateViewModel>(entity));
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
        public IActionResult Edit(Dncfireerror_adviceEditViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var entity = _dbContext.Dncfireerror_advice.FirstOrDefault(x => x.Id == model.Id);
                //entity.DncType = _dbContext.Dnctype.FirstOrDefault(x => x.K_Name_kw == model.DncType_Name);
                //entity.DncType_Name = entity.DncType.K_Name_kw;
                //entity.DncType_Name = model.DncType_Name;
                //entity.RealTime = model.RealTime;
                //entity.Evalue = model.Evalue;
                //entity.Advice = model.Advice;
                var dncboiler=_dbContext.Dncboiler.FirstOrDefault(x => x.Id == model.DncBoilerId);
                if (!dncboiler.Syntime.Value.ToString("yyyy-MM-dd HH:mm:ss").Equals(entity.RealTime.Value.ToString("yyyy-MM-dd HH:mm:ss")))
                {
                    response.SetError("操作已超时，请查看最新数据！");
                    return Ok(response);
                }
                else
                {
                    if (entity.CheckTime != null && entity.CheckTime.HasValue)
                    {

                    }
                    else
                    {
                        entity.CheckTime = DateTime.Now;
                        entity.CheckPerson = model.CheckPerson;
                    }
                    _dbContext.SaveChanges();
                    return Ok(response);
                }
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
                var parameters = ids.Split(",").Select((id, index) => new MySqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE Dncfireerror_advice SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
                parameters.Add(new MySqlParameter("@IsDeleted", (int)isDeleted));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
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
                var parameters = ids.Split(",").Select((id, index) => new MySqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE Dncfireerror_advice SET Status=@Status WHERE id IN ({0})", parameterNames);
                parameters.Add(new MySqlParameter("@Status", (int)status));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
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


        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult BatchOk(string fsts,string bid)
        {
            var response = ResponseModelFactory.CreateInstance;

            try
            {
                using (_dbContext)
                {

                    var dncboiler = _dbContext.Dncboiler.FirstOrDefault(x => x.Id ==int.Parse( bid));
                    string fid = fsts.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                    var entity = _dbContext.Dncfireerror_advice.FirstOrDefault(x => x.Id  == int.Parse(fid));
                    if (!dncboiler.Syntime.Value.ToString("yyyy-MM-dd HH:mm:ss").Equals(entity.RealTime.Value.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        response.SetError("操作已超时，请查看最新数据！");
                        return Ok(response);
                       
                    }

                    var sql = "UPDATE dncfireerror_advice SET CheckTime=NOW(),CheckPerson='"+ AuthContextService .CurrentUser.DisplayName+ "' WHERE id in (" + fsts + ")";
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
                        KeyValuePair<string, List< Dncfireerror_adviceCreateViewModel>> res = ValidateJson.Validation< Dncfireerror_adviceCreateViewModel>(fsts);

                        if (res.Key.Equals("ok"))
                        {
                            List< Dncfireerror_adviceCreateViewModel> arr = res.Value;
                            foreach ( Dncfireerror_adviceCreateViewModel item in arr)
                            {

      
                                
                                
                                
                                
                                
                                
                                var entity = _mapper.Map< Dncfireerror_adviceCreateViewModel, Dncfireerror_advice>(item);
                                
                                entity.DncType = _dbContext.Dnctype.FirstOrDefault(x => x.K_Name_kw == item.DncType_Name);
                                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == item.DncBoiler_Name);
                                
                                entity.Status = CommonEnum.Status.Normal;
                                _dbContext.Dncfireerror_advice.Add(entity);
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









