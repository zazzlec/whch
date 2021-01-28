

import axios from '@/libs/api.request'

export const getKyqresult_fastdataListAll = () => {
  return axios.request({
    url:  'Dnckyqresult_fastdata' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getKyqresult_fastdataList = (data) => {
  return axios.request({
    url:  'Dnckyqresult_fastdata' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createKyqresult_fastdata = (data) => {
  return axios.request({
    url:  'Dnckyqresult_fastdata' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadKyqresult_fastdata = (data) => {
  return axios.request({
    url: 'Dnckyqresult_fastdata' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editKyqresult_fastdata = (data) => {
  return axios.request({
    url: 'Dnckyqresult_fastdata' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteKyqresult_fastdata = (ids) => {
  return axios.request({
    url: 'Dnckyqresult_fastdata'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnckyqresult_fastdata'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateKyqresult_fastdata = (data) => {
  return axios.request({
    url:  'Dnckyqresult_fastdata' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

