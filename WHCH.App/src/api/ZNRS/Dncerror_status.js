

import axios from '@/libs/api.request'

export const getError_statusListAll = () => {
  return axios.request({
    url:  'Dncerror_status' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getError_statusList = (data) => {
  return axios.request({
    url:  'Dncerror_status' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createError_status = (data) => {
  return axios.request({
    url:  'Dncerror_status' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadError_status = (data) => {
  return axios.request({
    url: 'Dncerror_status' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editError_status = (data) => {
  return axios.request({
    url: 'Dncerror_status' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteError_status = (ids) => {
  return axios.request({
    url: 'Dncerror_status'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncerror_status'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateError_status = (data) => {
  return axios.request({
    url:  'Dncerror_status' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

