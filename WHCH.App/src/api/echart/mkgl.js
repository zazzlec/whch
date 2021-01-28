export const o2data={
    title: {
        text: "O2巡测数据分布图",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    tooltip: {
        position: 'right'
    },
    animation: false,
 
    grid: {
        x: 50,
        y: 80,
        x2: 20,
        y2: 80 //距离下边的距离
    },
    xAxis: {
        type: 'category',
        data: [],
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    yAxis: {
        type: 'category',
        data: ['深度一', '深度二', '深度三'],
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    visualMap: {
        min: 2,
        max: 4,
        calculable: true,
        orient: 'horizontal',
        left: 'center',
        bottom: '1%'
    },
    series: [{
        name: '燃烧值',
        type: 'heatmap',
        data: [],
        label: {
            normal: {
                show: true
            }
        },
        itemStyle: {
            emphasis: {
                shadowBlur: 10,
                shadowColor: 'rgba(0, 0, 0, 0.5)'
            }
        }
    }]
}

export const o2data_back={
    title: {
        text: "O2巡测数据分布图",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    tooltip: {
        position: 'right'
    },
    animation: false,
 
    grid: {
        x: 50,
        y: 80,
        x2: 20,
        y2: 80 //距离下边的距离
    },
    xAxis: {
        type: 'category',
        data: [],
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    yAxis: {
        type: 'category',
        data: ['深度一', '深度二', '深度三'],
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    visualMap: {
        min: 2,
        max: 4,
        calculable: true,
        orient: 'horizontal',
        left: 'center',
        bottom: '1%'
    },
    series: [{
        name: '燃烧值',
        type: 'heatmap',
        data: [],
        label: {
            normal: {
                show: true
            }
        },
        itemStyle: {
            emphasis: {
                shadowBlur: 10,
                shadowColor: 'rgba(0, 0, 0, 0.5)'
            }
        }
    }]
}

export const noxdata = {
    title: {
        text: "NOx巡测数据分布图",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    tooltip: {
        position: 'right'
    },
    animation: false,
    grid: {
        height: '50%',
        y: '10%'
    },
    grid: {
        x: 50,
        y: 80,
        x2: 20,
        y2: 80 //距离下边的距离
    },
    xAxis: {
        type: 'category',
        data: [],
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    yAxis: {
        type: 'category',
        data: ['深度一', '深度二', '深度三'],
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    visualMap: {
        min: 150,
        max: 250,
        calculable: true,
        orient: 'horizontal',
        left: 'center',
        bottom: '1%'
    },
    series: [{
        name: '燃烧值',
        type: 'heatmap',
        data: [],
        label: {
            normal: {
                show: true
            }
        },
        itemStyle: {
            emphasis: {
                shadowBlur: 10,
                shadowColor: 'rgba(0, 0, 0, 0.5)'
            }
        }
    }]
}

export const noxdata_back = {
    title: {
        text: "NOx巡测数据分布图",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    tooltip: {
        position: 'right'
    },
    animation: false,
    grid: {
        height: '50%',
        y: '10%'
    },
    grid: {
        x: 50,
        y: 80,
        x2: 20,
        y2: 80 //距离下边的距离
    },
    xAxis: {
        type: 'category',
        data: [],
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    yAxis: {
        type: 'category',
        data: ['深度一', '深度二', '深度三'],
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    visualMap: {
        min: 150,
        max: 250,
        calculable: true,
        orient: 'horizontal',
        left: 'center',
        bottom: '1%'
    },
    series: [{
        name: '燃烧值',
        type: 'heatmap',
        data: [],
        label: {
            normal: {
                show: true
            }
        },
        itemStyle: {
            emphasis: {
                shadowBlur: 10,
                shadowColor: 'rgba(0, 0, 0, 0.5)'
            }
        }
    }]
}
