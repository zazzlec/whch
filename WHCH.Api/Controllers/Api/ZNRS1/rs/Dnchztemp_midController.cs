
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
using WHCH.Api.RequestPayload.Rbac.Hztemp_mid;
using WHCH.Api.ViewModels.Rbac.Dnchztemp_mid;
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
    public class Dnchztemp_midController : ControllerBase
    {
        private readonly WHCHDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造control
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public Dnchztemp_midController(WHCHDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult List()
        {
            using (_dbContext)
            {
                var list = _dbContext.Dnchztemp_mid.ToList();
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
        public IActionResult List(Dnchztemp_midRequestPayload payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                var query = _dbContext.Dnchztemp_mid.AsQueryable();
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
                var data = list.Select(_mapper.Map< Dnchztemp_mid, Dnchztemp_midJsonModel>);

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
        public IActionResult Create(Dnchztemp_midCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var entity = _mapper.Map< Dnchztemp_midCreateViewModel, Dnchztemp_mid>(model);
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.Status = CommonEnum.Status.Normal;
                _dbContext.Dnchztemp_mid.Add(entity);
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
                var entity = _dbContext.Dnchztemp_mid.FirstOrDefault(x => (x.Id+"") == code);
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map< Dnchztemp_mid, Dnchztemp_midCreateViewModel>(entity));
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
        public IActionResult Edit(Dnchztemp_midEditViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {


                var entity = _dbContext.Dnchztemp_mid.FirstOrDefault(x => x.Id == model.Id);





                entity.RealTime = model.RealTime;
                entity.Flq_press_avg = model.Flq_press_avg;
                entity.Flq_temp_avg = model.Flq_temp_avg;
                entity.Mg_press_out_a = model.Mg_press_out_a;
                entity.Mg_press_out_b = model.Mg_press_out_b;
                entity.Mg_press_out_c = model.Mg_press_out_c;
                entity.Mg_press_out_d = model.Mg_press_out_d;
                entity.Mg_press_out_left_avg = model.Mg_press_out_left_avg;
                entity.Mg_press_out_right_avg = model.Mg_press_out_right_avg;
                entity.Dg_press_out_a = model.Dg_press_out_a;
                entity.Dg_press_out_b = model.Dg_press_out_b;
                entity.Dg_press_out_c = model.Dg_press_out_c;
                entity.Dg_press_out_d = model.Dg_press_out_d;
                entity.Dg_temp_out_a = model.Dg_temp_out_a;
                entity.Dg_temp_out_b = model.Dg_temp_out_b;
                entity.Dg_temp_out_c = model.Dg_temp_out_c;
                entity.Dg_temp_out_d = model.Dg_temp_out_d;
                entity.Dg_out_hz_a = model.Dg_out_hz_a;
                entity.Dg_out_hz_b = model.Dg_out_hz_b;
                entity.Dg_out_hz_c = model.Dg_out_hz_c;
                entity.Dg_out_hz_d = model.Dg_out_hz_d;
                entity.Dg_press_in_a = model.Dg_press_in_a;
                entity.Dg_press_in_b = model.Dg_press_in_b;
                entity.Dg_press_in_c = model.Dg_press_in_c;
                entity.Dg_press_in_d = model.Dg_press_in_d;
                entity.Dg_temp_in_a = model.Dg_temp_in_a;
                entity.Dg_temp_in_b = model.Dg_temp_in_b;
                entity.Dg_temp_in_c = model.Dg_temp_in_c;
                entity.Dg_temp_in_d = model.Dg_temp_in_d;
                entity.Dg_in_hz_a = model.Dg_in_hz_a;
                entity.Dg_in_hz_b = model.Dg_in_hz_b;
                entity.Dg_in_hz_c = model.Dg_in_hz_c;
                entity.Dg_in_hz_d = model.Dg_in_hz_d;
                entity.Fgp_press_out_a = model.Fgp_press_out_a;
                entity.Fgp_press_out_b = model.Fgp_press_out_b;
                entity.Fgp_press_out_c = model.Fgp_press_out_c;
                entity.Fgp_press_out_d = model.Fgp_press_out_d;
                entity.Fgp_temp_out_a = model.Fgp_temp_out_a;
                entity.Fgp_temp_out_b = model.Fgp_temp_out_b;
                entity.Fgp_temp_out_c = model.Fgp_temp_out_c;
                entity.Fgp_temp_out_d = model.Fgp_temp_out_d;
                entity.Fgp_out_hz_a = model.Fgp_out_hz_a;
                entity.Fgp_out_hz_b = model.Fgp_out_hz_b;
                entity.Fgp_out_hz_c = model.Fgp_out_hz_c;
                entity.Fgp_out_hz_d = model.Fgp_out_hz_d;
                entity.Fgp_press_in_a = model.Fgp_press_in_a;
                entity.Fgp_press_in_b = model.Fgp_press_in_b;
                entity.Fgp_press_in_c = model.Fgp_press_in_c;
                entity.Fgp_press_in_d = model.Fgp_press_in_d;
                entity.Fgp_temp_in_a = model.Fgp_temp_in_a;
                entity.Fgp_temp_in_b = model.Fgp_temp_in_b;
                entity.Fgp_temp_in_c = model.Fgp_temp_in_c;
                entity.Fgp_temp_in_d = model.Fgp_temp_in_d;
                entity.Fgp_in_hz_a = model.Fgp_in_hz_a;
                entity.Fgp_in_hz_b = model.Fgp_in_hz_b;
                entity.Fgp_in_hz_c = model.Fgp_in_hz_c;
                entity.Fgp_in_hz_d = model.Fgp_in_hz_d;
                entity.Hp_press_out_a = model.Hp_press_out_a;
                entity.Hp_press_out_b = model.Hp_press_out_b;
                entity.Hp_press_out_c = model.Hp_press_out_c;
                entity.Hp_press_out_d = model.Hp_press_out_d;
                entity.Hp_temp_out_a = model.Hp_temp_out_a;
                entity.Hp_temp_out_b = model.Hp_temp_out_b;
                entity.Hp_temp_out_c = model.Hp_temp_out_c;
                entity.Hp_temp_out_d = model.Hp_temp_out_d;
                entity.Hp_out_hz_a = model.Hp_out_hz_a;
                entity.Hp_out_hz_b = model.Hp_out_hz_b;
                entity.Hp_out_hz_c = model.Hp_out_hz_c;
                entity.Hp_out_hz_d = model.Hp_out_hz_d;
                entity.Hp_press_in_a = model.Hp_press_in_a;
                entity.Hp_press_in_b = model.Hp_press_in_b;
                entity.Hp_press_in_c = model.Hp_press_in_c;
                entity.Hp_press_in_d = model.Hp_press_in_d;
                entity.Hp_temp_in_a = model.Hp_temp_in_a;
                entity.Hp_temp_in_b = model.Hp_temp_in_b;
                entity.Hp_temp_in_c = model.Hp_temp_in_c;
                entity.Hp_temp_in_d = model.Hp_temp_in_d;
                entity.Hp_in_hz_a = model.Hp_in_hz_a;
                entity.Hp_in_hz_b = model.Hp_in_hz_b;
                entity.Hp_in_hz_c = model.Hp_in_hz_c;
                entity.Hp_in_hz_d = model.Hp_in_hz_d;
                entity.Mg_temp_out_a = model.Mg_temp_out_a;
                entity.Mg_temp_out_b = model.Mg_temp_out_b;
                entity.Mg_temp_out_c = model.Mg_temp_out_c;
                entity.Mg_temp_out_d = model.Mg_temp_out_d;
                entity.Mg_out_hz_a = model.Mg_out_hz_a;
                entity.Mg_out_hz_b = model.Mg_out_hz_b;
                entity.Mg_out_hz_c = model.Mg_out_hz_c;
                entity.Mg_out_hz_d = model.Mg_out_hz_d;
                entity.Mg_press_in_a = model.Mg_press_in_a;
                entity.Mg_press_in_b = model.Mg_press_in_b;
                entity.Mg_press_in_c = model.Mg_press_in_c;
                entity.Mg_press_in_d = model.Mg_press_in_d;
                entity.Mg_temp_in_a = model.Mg_temp_in_a;
                entity.Mg_temp_in_b = model.Mg_temp_in_b;
                entity.Mg_temp_in_c = model.Mg_temp_in_c;
                entity.Mg_temp_in_d = model.Mg_temp_in_d;
                entity.Mg_in_hz_a = model.Mg_in_hz_a;
                entity.Mg_in_hz_b = model.Mg_in_hz_b;
                entity.Mg_in_hz_c = model.Mg_in_hz_c;
                entity.Mg_in_hz_d = model.Mg_in_hz_d;
                entity.Dz_press_in_left = model.Dz_press_in_left;
                entity.Dz_press_in_right = model.Dz_press_in_right;
                entity.Gz_press_out_left = model.Gz_press_out_left;
                entity.Gz_press_out_right = model.Gz_press_out_right;
                entity.Dz_press_out_left = model.Dz_press_out_left;
                entity.Dz_press_out_right = model.Dz_press_out_right;
                entity.Dz_temp_out_left = model.Dz_temp_out_left;
                entity.Dz_temp_out_right = model.Dz_temp_out_right;
                entity.Dz_out_hz_left = model.Dz_out_hz_left;
                entity.Dz_out_hz_right = model.Dz_out_hz_right;
                entity.Dz_temp_in_left = model.Dz_temp_in_left;
                entity.Dz_temp_in_right = model.Dz_temp_in_right;
                entity.Dz_in_hz_left = model.Dz_in_hz_left;
                entity.Dz_in_hz_right = model.Dz_in_hz_right;
                entity.Gz_temp_out_left = model.Gz_temp_out_left;
                entity.Gz_temp_out_right = model.Gz_temp_out_right;
                entity.Gz_out_hz_left = model.Gz_out_hz_left;
                entity.Gz_out_hz_right = model.Gz_out_hz_right;
                entity.Gz_press_in_left = model.Gz_press_in_left;
                entity.Gz_press_in_right = model.Gz_press_in_right;
                entity.Gz_temp_in_left = model.Gz_temp_in_left;
                entity.Gz_temp_in_right = model.Gz_temp_in_right;
                entity.Gz_in_hz_left = model.Gz_in_hz_left;
                entity.Gz_in_hz_right = model.Gz_in_hz_right;
                entity.Left_qy_o2_left_avg = model.Left_qy_o2_left_avg;
                entity.Left_qy_o2_right_avg = model.Left_qy_o2_right_avg;
                entity.Left_qy_back_xdg_left_top = model.Left_qy_back_xdg_left_top;
                entity.Left_qy_back_xdg_right_top = model.Left_qy_back_xdg_right_top;
                entity.Right_qy_o2_left_avg = model.Right_qy_o2_left_avg;
                entity.Right_qy_o2_right_avg = model.Right_qy_o2_right_avg;
                entity.Right_qy_back_xdg_left_top = model.Right_qy_back_xdg_left_top;
                entity.Right_qy_back_xdg_right_top = model.Right_qy_back_xdg_right_top;
                entity.Left_czd_temp = model.Left_czd_temp;
                entity.Right_czd_temp = model.Right_czd_temp;
                entity.Left_qy_back_xdg_left_top3_avg = model.Left_qy_back_xdg_left_top3_avg;
                entity.Left_qy_back_xdg_right_top3_avg = model.Left_qy_back_xdg_right_top3_avg;
                entity.Left_lxd_top10_avg = model.Left_lxd_top10_avg;
                entity.Right_lxd_top10_avg = model.Right_lxd_top10_avg;
                entity.Right_qy_back_xdg_left_top3_avg = model.Right_qy_back_xdg_left_top3_avg;
                entity.Right_qy_back_xdg_right_top3_avg = model.Right_qy_back_xdg_right_top3_avg;
                entity.Left_qy_back_gp_temp = model.Left_qy_back_gp_temp;
                entity.Right_qy_back_gp_temp = model.Right_qy_back_gp_temp;
                entity.Left_qy_front_gp_temp = model.Left_qy_front_gp_temp;
                entity.Right_qy_front_gp_temp = model.Right_qy_front_gp_temp;
                entity.Left_qy_back_lxd_top10_avg = model.Left_qy_back_lxd_top10_avg;
                entity.Right_qy_back_lxd_top10_avg = model.Right_qy_back_lxd_top10_avg;
                entity.Left_qy_front_lxd_top10_avg = model.Left_qy_front_lxd_top10_avg;
                entity.Right_qy_front_lxd_top10_avg = model.Right_qy_front_lxd_top10_avg;
                entity.Dz_jws_press = model.Dz_jws_press;
                entity.Dz_jws_temp = model.Dz_jws_temp;
                entity.Dz_jws_hz = model.Dz_jws_hz;
                entity.Dz_jwq_front_left = model.Dz_jwq_front_left;
                entity.Dz_jwq_back_left = model.Dz_jwq_back_left;
                entity.Dz_jwq_front_right = model.Dz_jwq_front_right;
                entity.Dz_jwq_back_right = model.Dz_jwq_back_right;
                entity.Dz_jwq_front_hz_left = model.Dz_jwq_front_hz_left;
                entity.Dz_jwq_back_hz_left = model.Dz_jwq_back_hz_left;
                entity.Dz_jwq_front_hz_right = model.Dz_jwq_front_hz_right;
                entity.Dz_jwq_back_hz_right = model.Dz_jwq_back_hz_right;
                entity.Zrq_jws_left = model.Zrq_jws_left;
                entity.Zrq_jws_right = model.Zrq_jws_right;
                entity.Fgp_hz_design = model.Fgp_hz_design;
                entity.Hp_hz_design = model.Hp_hz_design;
                entity.Mg_hz_design = model.Mg_hz_design;
                entity.Dz_hz_design = model.Dz_hz_design;
                entity.Gz_hz_design = model.Gz_hz_design;
                entity.Grq_jws_hz = model.Grq_jws_hz;
                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.DncBoiler_Name = model.DncBoiler_Name;
                entity.Left_qy_back_xdg_left_top_point = model.Left_qy_back_xdg_left_top_point;
                entity.Left_qy_back_xdg_right_top_point = model.Left_qy_back_xdg_right_top_point;
                entity.Right_qy_back_xdg_left_top_point = model.Right_qy_back_xdg_left_top_point;
                entity.Right_qy_back_xdg_right_top_point = model.Right_qy_back_xdg_right_top_point;
                entity.Left_qy_back_xdg_left_top3 = model.Left_qy_back_xdg_left_top3;
                entity.Left_qy_back_xdg_right_top3 = model.Left_qy_back_xdg_right_top3;
                entity.Right_qy_back_xdg_left_top3 = model.Right_qy_back_xdg_left_top3;
                entity.Right_qy_back_xdg_right_top3 = model.Right_qy_back_xdg_right_top3;
                entity.Dg_hz_design = model.Dg_hz_design;

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
                var sql = string.Format("UPDATE Dnchztemp_mid SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
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
                var sql = string.Format("UPDATE Dnchztemp_mid SET Status=@Status WHERE id IN ({0})", parameterNames);
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
                        KeyValuePair<string, List< Dnchztemp_midCreateViewModel>> res = ValidateJson.Validation< Dnchztemp_midCreateViewModel>(fsts);

                        if (res.Key.Equals("ok"))
                        {
                            List< Dnchztemp_midCreateViewModel> arr = res.Value;
                            foreach ( Dnchztemp_midCreateViewModel item in arr)
                            {

      
                                
                                
                                
                                
                                
                                
                                var entity = _mapper.Map< Dnchztemp_midCreateViewModel, Dnchztemp_mid>(item);
                                
                                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == item.DncBoiler_Name);
                                
                                entity.Status = CommonEnum.Status.Normal;
                                _dbContext.Dnchztemp_mid.Add(entity);
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









