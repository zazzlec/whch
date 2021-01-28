
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
using WHCH.Api.RequestPayload.Rbac.Expand3d_base;
using WHCH.Api.ViewModels.Rbac.Dncexpand3d_base;
using System.Transactions;
using System.Collections.Generic;
using WHCH.Api.Utils;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;

namespace WHCH.Api.Controllers.Api.WHCH1
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/WHCH1/[controller]/[action]")]
    [ApiController]
    //[CustomAuthorize]
    public class Dncexpand3d_baseController : ControllerBase
    {
        private readonly WHCHDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造control
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public Dncexpand3d_baseController(WHCHDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult List()
        {
            using (_dbContext)
            {
                var list = _dbContext.Dncexpand3d_base.ToList();
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
        public IActionResult List(Dncexpand3d_baseRequestPayload payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                var query = _dbContext.Dncexpand3d_base.Include(x=>x.Dncexpandgroup).AsQueryable();
                //模糊查询
                if (!string.IsNullOrEmpty(payload.Kw))
                {
                    query = query.Where(x =>   x.K_Name_kw.Contains(payload.Kw.Trim())  );
                }

                if (!string.IsNullOrEmpty(payload.gid))
                {
                    query = query.Where(x => x.DncexpandgroupId==int.Parse(payload.gid));
                }
                if (payload.boilerid != -1)
                {
                    query = query.Where(x => x.DncBoilerId == payload.boilerid);
                }
                //是否删除，是否启用
                if (payload.IsDeleted > CommonEnum.IsDeleted.All)
                {
                    query = query.Where(x => x.IsDeleted == payload.IsDeleted);
                }
                if (payload.Status > CommonEnum.Status.All)
                {
                    query = query.Where(x => x.Status == payload.Status);
                }

                

                query = query.OrderBy("DncBoilerId", false).ThenBy(x=> int.Parse(x.R_GroupId));//.ThenBy("cast(R_GroupId as UNSIGNED INTEGER)", false);

                var qq = query.Paged(payload.CurrentPage, payload.PageSize);
                //qq.to
                //Console.WriteLine(qq.ToSql());
                var list = qq.ToList();
                var list2 = new List<Dncexpand3d_base>();
                foreach (var item in list)
                {
                    item.X_errornum = item.Dncexpandgroup.X_errornum+"";
                    item.Y_errornum = item.Dncexpandgroup.Y_errornum + "";
                    item.Z_errornum = item.Dncexpandgroup.Z_errornum + "";
                    list2.Add(item);
                }
                var totalCount = query.Count();
                var data = list2.Select(_mapper.Map< Dncexpand3d_base, Dncexpand3d_baseJsonModel>);






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
        public IActionResult Create(Dncexpand3d_baseCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (model.K_Name_kw.Trim().Length <= 0)
            {
                response.SetFailed("请输入点位名称");
                return Ok(response);
            }
            try
            {
                using (_dbContext)
                {
                    ////3 只有未删除的有重复才提示
                    //if (_dbContext.Dncexpand3d_base.Count(x => x.K_Name_kw == model.K_Name_kw && x.IsDeleted == CommonEnum.IsDeleted.No) > 0)
                    //{
                    //    response.SetFailed(model.K_Name_kw + "已存在");
                    //    return Ok(response);
                    //}
                    ////4 删除的有重复就真删掉
                    //if (_dbContext.Dncexpand3d_base.Count(x => x.K_Name_kw == model.K_Name_kw && x.IsDeleted == CommonEnum.IsDeleted.Yes) > 0)
                    //{
                    //    var entity2 = _dbContext.Dncexpand3d_base.FirstOrDefault(x => x.K_Name_kw == model.K_Name_kw && x.IsDeleted == CommonEnum.IsDeleted.Yes);
                    //    _dbContext.Dncexpand3d_base.Remove(entity2);
                    //}
                    var entity = _mapper.Map<Dncexpand3d_baseCreateViewModel, Dncexpand3d_base>(model);
                    entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncBoiler_Name);
                    entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                    if (string.IsNullOrEmpty(model.Dncexpandgroup_Name))
                    {
                        model.Dncexpandgroup_Name = "无";
                    }
                    entity.Dncexpandgroup = _dbContext.Dncexpandgroup.FirstOrDefault(x => (x.K_Name_kw + "") == model.Dncexpandgroup_Name && x.DncboilerId== entity.DncBoiler.Id);


                    entity.Dncexpandgroup_Name = entity.Dncexpandgroup.K_Name_kw;
                    entity.Status = CommonEnum.Status.Normal;
                    _dbContext.Dncexpand3d_base.Add(entity);
                    _dbContext.SaveChanges();

                    response.SetSuccess();
                    return Ok(response);
                }
            }
            catch (Exception rr)
            {
                response.SetError(rr.Message);
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
                var entity = _dbContext.Dncexpand3d_base.FirstOrDefault(x => x.Id == int.Parse( code));
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map< Dncexpand3d_base, Dncexpand3d_baseCreateViewModel>(entity));
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
        public IActionResult Edit(Dncexpand3d_baseEditViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {


                var entity = _dbContext.Dncexpand3d_base.FirstOrDefault(x => x.Id == model.Id);


                
                ////1 未删除的其他记录重复校验 K_Name_kw
                //if (_dbContext.Dncexpand3d_base.Count(x => x.K_Name_kw == model.K_Name_kw && x.Id != model.Id && x.IsDeleted == CommonEnum.IsDeleted.No) > 0 )
                //{
                //    response.SetFailed(model.K_Name_kw + "已存在");
                //    return Ok(response);
                //}
                ////2 已删除的其他记录重复的真删 K_Name_kw
                //if (_dbContext.Dncexpand3d_base.Count(x => x.K_Name_kw == model.K_Name_kw && x.Id != model.Id && x.IsDeleted == CommonEnum.IsDeleted.Yes) > 0)
                //{
                //    var entity2 = _dbContext.Dncexpand3d_base.FirstOrDefault(x => x.K_Name_kw == model.K_Name_kw && x.Id != model.Id && x.IsDeleted == CommonEnum.IsDeleted.Yes);
                //    _dbContext.Dncexpand3d_base.Remove(entity2);
                //}
                



                entity.K_Name_kw = model.K_Name_kw;
                entity.R_GroupId = model.R_GroupId;
                entity.R_X_axis = model.R_X_axis;
                entity.R_Y_axis = model.R_Y_axis;
                entity.R_X_up = model.R_X_up;
                entity.R_X_down = model.R_X_down;
                entity.R_Y_up = model.R_Y_up;
                entity.R_Y_down = model.R_Y_down;
                entity.R_Z_up = model.R_Z_up;
                entity.R_Z_down = model.R_Z_down;
                entity.Remarks = model.Remarks;
                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                if (string.IsNullOrEmpty(model.Dncexpandgroup_Name))
                {
                    model.Dncexpandgroup_Name = "无";
                }
                entity.Dncexpandgroup = _dbContext.Dncexpandgroup.FirstOrDefault(x => x.K_Name_kw == model.Dncexpandgroup_Name && x.DncboilerId == entity.DncBoiler.Id);
                entity.Dncexpandgroup_Name = entity.Dncexpandgroup.K_Name_kw;

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
                    var sql = string.Format("UPDATE Dncexpand3d_base SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
                    parameters.Add(new MySqlParameter("@IsDeleted", (int)isDeleted));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }else{
                    var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dncexpand3d_base SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
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
                    var sql = string.Format("UPDATE Dncexpand3d_base SET Status=@Status WHERE id IN ({0})", parameterNames);
                    parameters.Add(new MySqlParameter("@Status", (int)status));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }else{
                    var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dncexpand3d_base SET Status=@Status WHERE id IN ({0})", parameterNames);
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
                        KeyValuePair<string, List< Dncexpand3d_baseCreateViewModel>> res = ValidateJson.Validation< Dncexpand3d_baseCreateViewModel>(fsts);

                        if (res.Key.Equals("ok"))
                        {
                            List< Dncexpand3d_baseCreateViewModel> arr = res.Value;
                            foreach ( Dncexpand3d_baseCreateViewModel item in arr)
                            {

                                if (item.K_Name_kw.Trim().Length <= 0)
                                {
                                    response.SetFailed("请输入点位名称");
                                    return Ok(response);
                                }
      
                                
                                
                                ////5 只有未删除的有重复才提示
                                //if (_dbContext.Dncexpand3d_base.Count(x => x.K_Name_kw == item.K_Name_kw && x.IsDeleted == CommonEnum.IsDeleted.No) > 0)
                                //{
                                //    response.SetFailed(item.K_Name_kw+"已存在");
                                //    return Ok(response);
                                //}
                                ////6 删除的有重复就真删掉
                                //if (_dbContext.Dncexpand3d_base.Count(x => x.K_Name_kw == item.K_Name_kw && x.IsDeleted == CommonEnum.IsDeleted.Yes) > 0)
                                //{
                                //    var entity2 = _dbContext.Dncexpand3d_base.FirstOrDefault(x => x.K_Name_kw == item.K_Name_kw  && x.IsDeleted == CommonEnum.IsDeleted.Yes);
                                //    _dbContext.Dncexpand3d_base.Remove(entity2);
                                //}
                                
                                
                                
                                
                                var entity = _mapper.Map< Dncexpand3d_baseCreateViewModel, Dncexpand3d_base>(item);
                                
                                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == item.DncBoiler_Name);
                                entity.DncBoiler_Name = item.DncBoiler_Name;

                                if (string.IsNullOrEmpty(item.Dncexpandgroup_Name))
                                {
                                    item.Dncexpandgroup_Name = "无";
                                }
                                entity.Dncexpandgroup = _dbContext.Dncexpandgroup.FirstOrDefault(x => x.K_Name_kw == item.Dncexpandgroup_Name && x.DncboilerId == entity.DncBoiler.Id);
                                entity.Dncexpandgroup_Name = item.Dncexpandgroup_Name;
                                entity.Status = CommonEnum.Status.Normal;
                                _dbContext.Dncexpand3d_base.Add(entity);
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









