

import axios from '@/libs/api.request'

export const getWindbaseListAll = () => {
  return axios.request({
    url:  'Dncwindbase' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getWindbaseList = (data) => {
  return axios.request({
    url:  'Dncwindbase' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createWindbase = (data) => {
  return axios.request({
    url:  'Dncwindbase' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadWindbase = (data) => {
  return axios.request({
    url: 'Dncwindbase' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editWindbase = (data) => {
  return axios.request({
    url: 'Dncwindbase' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteWindbase = (ids) => {
  return axios.request({
    url: 'Dncwindbase'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncwindbase'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateWindbase = (data) => {
  return axios.request({
    url:  'Dncwindbase' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

