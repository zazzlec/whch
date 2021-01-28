

import axios from '@/libs/api.request'

export const getExpand3d_baseListAll = () => {
  return axios.request({
    url:  'Dncexpand3d_base' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getExpand3d_baseList = (data) => {
  return axios.request({
    url:  'Dncexpand3d_base' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createExpand3d_base = (data) => {
  return axios.request({
    url:  'Dncexpand3d_base' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadExpand3d_base = (data) => {
  return axios.request({
    url: 'Dncexpand3d_base' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editExpand3d_base = (data) => {
  return axios.request({
    url: 'Dncexpand3d_base' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteExpand3d_base = (ids) => {
  return axios.request({
    url: 'Dncexpand3d_base'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncexpand3d_base'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateExpand3d_base = (data) => {
  return axios.request({
    url:  'Dncexpand3d_base' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

