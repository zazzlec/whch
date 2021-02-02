

import axios from '@/libs/api.request'

export const getLzburnListAll = () => {
  return axios.request({
    url:  'Dnclzburn' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getLzburnList = (data) => {
  return axios.request({
    url:  'Dnclzburn' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createLzburn = (data) => {
  return axios.request({
    url:  'Dnclzburn' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadLzburn = (data) => {
  return axios.request({
    url: 'Dnclzburn' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editLzburn = (data) => {
  return axios.request({
    url: 'Dnclzburn' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteLzburn = (ids) => {
  return axios.request({
    url: 'Dnclzburn'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnclzburn'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateLzburn = (data) => {
  return axios.request({
    url:  'Dnclzburn' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

