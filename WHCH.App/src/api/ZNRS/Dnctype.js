

import axios from '@/libs/api.request'

export const getTypeListAll = () => {
  return axios.request({
    url:  'Dnctype' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getTypeList = (data) => {
  return axios.request({
    url:  'Dnctype' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createType = (data) => {
  return axios.request({
    url:  'Dnctype' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadType = (data) => {
  return axios.request({
    url: 'Dnctype' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editType = (data) => {
  return axios.request({
    url: 'Dnctype' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteType = (ids) => {
  return axios.request({
    url: 'Dnctype'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnctype'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateType = (data) => {
  return axios.request({
    url:  'Dnctype' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

