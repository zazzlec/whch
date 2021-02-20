

import axios from '@/libs/api.request'

export const getPointkks_dataListAll = () => {
  return axios.request({
    url:  'Dncpointkks_data' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getPointkks_dataList = (data) => {
  return axios.request({
    url:  'Dncpointkks_data' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createPointkks_data = (data) => {
  return axios.request({
    url:  'Dncpointkks_data' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadPointkks_data = (data) => {
  return axios.request({
    url: 'Dncpointkks_data' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editPointkks_data = (data) => {
  return axios.request({
    url: 'Dncpointkks_data' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deletePointkks_data = (ids) => {
  return axios.request({
    url: 'Dncpointkks_data'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncpointkks_data'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreatePointkks_data = (data) => {
  return axios.request({
    url:  'Dncpointkks_data' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

