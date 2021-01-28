
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
using WHCH.Api.RequestPayload.Rbac.Hztemp_real;
using WHCH.Api.ViewModels.Rbac.Dnchztemp_real;
using System.Transactions;
using System.Collections.Generic;
using WHCH.Api.dataoperate;
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
    public class Dnchztemp_realController : ControllerBase
    {
        private readonly WHCHDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造control
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public Dnchztemp_realController(WHCHDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region 受热面焓增计算、存储
        /// <summary>
        /// 查询请求
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Hztemp_insert()
        {
            int boilerid = 1;
            DateTime csyntime = DateTime.Parse("2020-03-19 23:20:01");
            var response = ResponseModelFactory.CreateInstance;
            SynTask.Hztemp(boilerid, csyntime);
            response.SetSuccess("焓增数据正在刷新");
            return Ok(response);

        }
        #endregion
        [HttpGet]
        public IActionResult List()
        {
            using (_dbContext)
            {
                var list = _dbContext.Dnchztemp_real.ToList();
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
        public IActionResult List(Dnchztemp_realRequestPayload payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                var query = _dbContext.Dnchztemp_real.AsQueryable();
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
                if (payload.FirstSort != null)
                {
                    query = query.OrderBy(payload.FirstSort.Field, payload.FirstSort.Direct == "DESC");
                }
                var list = query.Paged(payload.CurrentPage, payload.PageSize).ToList();
                var totalCount = query.Count();
                var data = list.Select(_mapper.Map< Dnchztemp_real, Dnchztemp_realJsonModel>);

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
        public IActionResult Create(Dnchztemp_realCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var entity = _mapper.Map< Dnchztemp_realCreateViewModel, Dnchztemp_real>(model);
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.Status = CommonEnum.Status.Normal;
                _dbContext.Dnchztemp_real.Add(entity);
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
                var entity = _dbContext.Dnchztemp_real.FirstOrDefault(x => (x.Id+"") == code);
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map< Dnchztemp_real, Dnchztemp_realCreateViewModel>(entity));
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
        public IActionResult Edit(Dnchztemp_realEditViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {


                var entity = _dbContext.Dnchztemp_real.FirstOrDefault(x => x.Id == model.Id);


                entity.RealTime = model.RealTime;
                entity.Dg_hz_a = model.Dg_hz_a;
                entity.Dg_hz_b = model.Dg_hz_b;
                entity.Dg_hz_c = model.Dg_hz_c;
                entity.Dg_hz_d = model.Dg_hz_d;
                entity.Fgp_hz_a = model.Fgp_hz_a;
                entity.Fgp_hz_b = model.Fgp_hz_b;
                entity.Fgp_hz_c = model.Fgp_hz_c;
                entity.Fgp_hz_d = model.Fgp_hz_d;
                entity.Hp_hz_a = model.Hp_hz_a;
                entity.Hp_hz_b = model.Hp_hz_b;
                entity.Hp_hz_c = model.Hp_hz_c;
                entity.Hp_hz_d = model.Hp_hz_d;
                entity.Mg_hz_a = model.Mg_hz_a;
                entity.Mg_hz_b = model.Mg_hz_b;
                entity.Mg_hz_c = model.Mg_hz_c;
                entity.Mg_hz_d = model.Mg_hz_d;
                entity.Dz_hz_left = model.Dz_hz_left;
                entity.Dz_hz_right = model.Dz_hz_right;
                entity.Gz_hz_left = model.Gz_hz_left;
                entity.Gz_hz_right = model.Gz_hz_right;
                entity.Dg_temp_out_left = model.Dg_temp_out_left;
                entity.Dg_temp_out_right = model.Dg_temp_out_right;
                entity.Fgp_temp_out_left = model.Fgp_temp_out_left;
                entity.Fgp_temp_out_right = model.Fgp_temp_out_right;
                entity.Hp_temp_out_left = model.Hp_temp_out_left;
                entity.Hp_temp_out_right = model.Hp_temp_out_right;
                entity.Mg_temp_out_left = model.Mg_temp_out_left;
                entity.Mg_temp_out_right = model.Mg_temp_out_right;
                entity.Dz_temp_out_left = model.Dz_temp_out_left;
                entity.Dz_temp_out_right = model.Dz_temp_out_right;
                entity.Gz_temp_out_left = model.Gz_temp_out_left;
                entity.Gz_temp_out_right = model.Gz_temp_out_right;
                entity.Nox_avg = model.Nox_avg;
                entity.Nox_high = model.Nox_high;
                entity.Nox_low = model.Nox_low;
                entity.O2_avg = model.O2_avg;
                entity.O2_high = model.O2_high;
                entity.O2_low = model.O2_low;
                entity.Yl_fh_out = model.Yl_fh_out;
                entity.Cql = model.Cql;
                entity.Dz_jws_mh = model.Dz_jws_mh;
                entity.Gz_temp_mh = model.Gz_temp_mh;
                entity.Mg_temp_mh = model.Mg_temp_mh;
                entity.Dg_zwxs = model.Dg_zwxs;
                entity.Fgp_zwxs = model.Fgp_zwxs;
                entity.Hp_zwxs = model.Hp_zwxs;
                entity.Mg_zwxs = model.Mg_zwxs;
                entity.Dz_zwxs = model.Dz_zwxs;
                entity.Gz_zwxs = model.Gz_zwxs;
                entity.Grq_jws_1a = model.Grq_jws_1a;
                entity.Grq_jws_1b = model.Grq_jws_1b;
                entity.Grq_jws_1c = model.Grq_jws_1c;
                entity.Grq_jws_1d = model.Grq_jws_1d;
                entity.Grq_jws_2a = model.Grq_jws_2a;
                entity.Grq_jws_2b = model.Grq_jws_2b;
                entity.Grq_jws_2c = model.Grq_jws_2c;
                entity.Grq_jws_2d = model.Grq_jws_2d;
                entity.Grq_jws_3a = model.Grq_jws_3a;
                entity.Grq_jws_3b = model.Grq_jws_3b;
                entity.Grq_jws_3c = model.Grq_jws_3c;
                entity.Grq_jws_3d = model.Grq_jws_3d;
                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.DncBoiler_Name = model.DncBoiler_Name;

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
                var parameters = ids.Split(",").Select((id, index) => new MySqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE Dnchztemp_real SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
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
                var sql = string.Format("UPDATE Dnchztemp_real SET Status=@Status WHERE id IN ({0})", parameterNames);
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
                        KeyValuePair<string, List< Dnchztemp_realCreateViewModel>> res = ValidateJson.Validation< Dnchztemp_realCreateViewModel>(fsts);

                        if (res.Key.Equals("ok"))
                        {
                            List< Dnchztemp_realCreateViewModel> arr = res.Value;
                            foreach ( Dnchztemp_realCreateViewModel item in arr)
                            {

      
                                
                                
                                
                                
                                
                                
                                var entity = _mapper.Map< Dnchztemp_realCreateViewModel, Dnchztemp_real>(item);
                                
                                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == item.DncBoiler_Name);
                                
                                entity.Status = CommonEnum.Status.Normal;
                                _dbContext.Dnchztemp_real.Add(entity);
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









