

import axios from '@/libs/api.request'

export const getHztemp_pointListAll = () => {
  return axios.request({
    url:  'Dnchztemp_point' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getHztemp_pointList = (data) => {
  return axios.request({
    url:  'Dnchztemp_point' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createHztemp_point = (data) => {
  return axios.request({
    url:  'Dnchztemp_point' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadHztemp_point = (data) => {
  return axios.request({
    url: 'Dnchztemp_point' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editHztemp_point = (data) => {
  return axios.request({
    url: 'Dnchztemp_point' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteHztemp_point = (ids) => {
  return axios.request({
    url: 'Dnchztemp_point'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnchztemp_point'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateHztemp_point = (data) => {
  return axios.request({
    url:  'Dnchztemp_point' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

