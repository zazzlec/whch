

import axios from '@/libs/api.request'

export const getKyqresultListAll = () => {
  return axios.request({
    url:  'Dnckyqresult' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getKyqresultList = (data) => {
  return axios.request({
    url:  'Dnckyqresult' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createKyqresult = (data) => {
  return axios.request({
    url:  'Dnckyqresult' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadKyqresult = (data) => {
  return axios.request({
    url: 'Dnckyqresult' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editKyqresult = (data) => {
  return axios.request({
    url: 'Dnckyqresult' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteKyqresult = (ids) => {
  return axios.request({
    url: 'Dnckyqresult'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnckyqresult'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateKyqresult = (data) => {
  return axios.request({
    url:  'Dnckyqresult' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

