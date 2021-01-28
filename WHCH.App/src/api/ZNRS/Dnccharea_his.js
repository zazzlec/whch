

import axios from '@/libs/api.request'

export const getCharea_hisListAll = () => {
  return axios.request({
    url:  'Dnccharea_his' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getCharea_hisList = (data) => {
  return axios.request({
    url:  'Dnccharea_his' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createCharea_his = (data) => {
  return axios.request({
    url:  'Dnccharea_his' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadCharea_his = (data) => {
  return axios.request({
    url: 'Dnccharea_his' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editCharea_his = (data) => {
  return axios.request({
    url: 'Dnccharea_his' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteCharea_his = (ids) => {
  return axios.request({
    url: 'Dnccharea_his'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnccharea_his'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateCharea_his = (data) => {
  return axios.request({
    url:  'Dnccharea_his' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

