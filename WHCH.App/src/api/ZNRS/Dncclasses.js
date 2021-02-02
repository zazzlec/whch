

import axios from '@/libs/api.request'

export const getClassesListAll = () => {
  return axios.request({
    url:  'Dncclasses' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getClassesList = (data) => {
  return axios.request({
    url:  'Dncclasses' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createClasses = (data) => {
  return axios.request({
    url:  'Dncclasses' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadClasses = (data) => {
  return axios.request({
    url: 'Dncclasses' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editClasses = (data) => {
  return axios.request({
    url: 'Dncclasses' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteClasses = (ids) => {
  return axios.request({
    url: 'Dncclasses'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncclasses'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateClasses = (data) => {
  return axios.request({
    url:  'Dncclasses' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

