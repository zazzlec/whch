

import axios from '@/libs/api.request'

export const getHztemp_midListAll = () => {
  return axios.request({
    url:  'Dnchztemp_mid' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getHztemp_midList = (data) => {
  return axios.request({
    url:  'Dnchztemp_mid' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createHztemp_mid = (data) => {
  return axios.request({
    url:  'Dnchztemp_mid' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadHztemp_mid = (data) => {
  return axios.request({
    url: 'Dnchztemp_mid' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editHztemp_mid = (data) => {
  return axios.request({
    url: 'Dnchztemp_mid' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteHztemp_mid = (ids) => {
  return axios.request({
    url: 'Dnchztemp_mid'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnchztemp_mid'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateHztemp_mid = (data) => {
  return axios.request({
    url:  'Dnchztemp_mid' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

