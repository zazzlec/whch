

import axios from '@/libs/api.request'

export const getHztemp_realListAll = () => {
  return axios.request({
    url:  'Dnchztemp_real' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getHztemp_realList = (data) => {
  return axios.request({
    url:  'Dnchztemp_real' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createHztemp_real = (data) => {
  return axios.request({
    url:  'Dnchztemp_real' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadHztemp_real = (data) => {
  return axios.request({
    url: 'Dnchztemp_real' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editHztemp_real = (data) => {
  return axios.request({
    url: 'Dnchztemp_real' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteHztemp_real = (ids) => {
  return axios.request({
    url: 'Dnchztemp_real'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnchztemp_real'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateHztemp_real = (data) => {
  return axios.request({
    url:  'Dnchztemp_real' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

