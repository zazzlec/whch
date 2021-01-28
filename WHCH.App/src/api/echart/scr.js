export const option1 ={

    title: {
        text: '1号格进出口NOx和脱销效率对比',
        textStyle: {
            fontSize: 16,
            color: "#3e3e3e"
        },
        // padding:[15,80]
        left: "center",
        top: "0px"

    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            crossStyle: {
                color: '#999'
            }
        },
        formatter:'{b}' +'<br/>'+'{a0}: {c0}'+'<br/>'+'{a1}: {c1}'+'<br/>'+'{a2}: {c2}'+'%'
    },
    // toolbox: {
    //     feature: {
    //         dataView: {show: true, readOnly: false},
    //         magicType: {show: true, type: ['line', 'bar']},
    //         restore: {show: true},
    //         saveAsImage: {show: true}
    //     }
    // },
    legend: {
        data: ['进口NOx', '出口NOx', '脱销效率'],
        left: "center",
        top: "20px"
    },
    xAxis: [
        {
            type: 'category',
            data: [],
            axisPointer: {
                type: 'shadow'
            },
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            }
        }
    ],
    yAxis: [
        {
            type: 'value',
            name: 'NOx',
            min: 0,
            max: 250,
            interval: 50,
            axisLabel: {
                formatter: '{value}'
            }
        },
        {
            type: 'value',
            name: '脱硝效率',
            min: 0,
            max: 100,
            interval: 20,
            axisLabel: {
                formatter: '{value}%'
            }
        }
    ],
    series: [
         {
            name: '进口NOx',
            type: 'bar',
            yAxisIndex: 0,
            data: []
        },
        {
            name: '出口NOx',
            type: 'bar',
            yAxisIndex: 0,
            data: []
        },
       
        {
            name: '脱硝效率',
            type: 'line',
            smooth:true,
            yAxisIndex: 1,
            data: []
        }
    ]
};

export const option1_back ={

    title: {
        text: '1号格进出口NOx和脱销效率对比',
        textStyle: {
            fontSize: 16,
            color: "#3e3e3e"
        },
        // padding:[15,80]
        left: "center",
        top: "0px"

    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            crossStyle: {
                color: '#999'
            }
        },
        formatter:'{b}' +'<br/>'+'{a0}: {c0}'+'<br/>'+'{a1}: {c1}'+'<br/>'+'{a2}: {c2}'+'%'
    },
    dataZoom:[{
        type: 'inside',
        start: 90,
        end: 100
    }, {
        bottom:"0%", 
        handleIcon: 'M10.7,11.9v-1.3H9.3v1.3c-4.9,0.3-8.8,4.4-8.8,9.4c0,5,3.9,9.1,8.8,9.4v1.3h1.3v-1.3c4.9-0.3,8.8-4.4,8.8-9.4C19.5,16.3,15.6,12.2,10.7,11.9z M13.3,24.4H6.7V23h6.6V24.4z M13.3,19.6H6.7v-1.4h6.6V19.6z',
        handleSize: '80%',
        handleStyle: {
            color: '#fff',
            shadowBlur: 3,
            shadowColor: '#11111',
            shadowOffsetX: 2,
            shadowOffsetY: 2
        }
    }],
    toolbox: {
        feature: {
            dataView: {show: true, readOnly: false},
            magicType: {show: true, type: ['line', 'bar']},
            restore: {show: true},
            saveAsImage: {show: true}
        }
    },
    legend: {
        data: ['进口NOx', '出口NOx', '脱销效率'],
        left: "center",
        top: "20px"
    },
    xAxis: [
        {
            type: 'category',
            data: [],
            axisPointer: {
                type: 'shadow'
            },
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            }
        }
    ],
    yAxis: [
        {
            type: 'value',
            name: 'NOx',
            min: 0,
            max: 250,
            interval: 50,
            axisLabel: {
                formatter: '{value}'
            }
        },
        {
            type: 'value',
            name: '脱硝效率',
            min: 0,
            max: 100,
            interval: 20,
            axisLabel: {
                formatter: '{value}%'
            }
        }
    ],
    series: [
         {
            name: '进口NOx',
            type: 'bar',
            yAxisIndex: 0,
            data: []
        },
        {
            name: '出口NOx',
            type: 'bar',
            yAxisIndex: 0,
            data: []
        },
       
        {
            name: '脱硝效率',
            type: 'line',
            smooth:true,
            yAxisIndex: 1,
            data: []
        }
    ]
};

export const option2 ={

    title: {
        text: '1号格氨逃逸脱硝效率对比图',
        textStyle: {
            fontSize: 16,
            color: "#3e3e3e"
        },
        // padding:[15,80]
        left: "center",
        top: "0px"

    },
    tooltip: {
        trigger: 'axis',
        formatter: '{b}' +'<br/>'+ '{a0}: {c0}'+'ppm'+'<br/>'+'{a1}: {c1}'+'%'
    },
    legend: {
        data: ['氨逃逸', '脱硝效率'],
        left: "center",
        top: "20px"
    },
    xAxis: {
        type: 'category',
        data: [],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            },
            rotate: 45
        }
    },
     
    yAxis: [   
        {
            name:"氨逃逸(ppm)",
            gridIndex: 0,  
                      
                   
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false
            },
            scale:true,
            min:0,
            max:10
        },
        {
        name:"脱硝效率(%)",
        gridIndex:0,  
                      
           
        axisLabel: {
            show: true,
             formatter: '{value}%',
            textStyle: {
                color: '#3e3e3e'
            }
        },
        splitLine: {
            show: false
        },
        scale:true,
        min:0,
        max:100
		}]
        ,
    series: [{
                name:'氨逃逸',
                data: [],
                type: 'line',
                smooth:true,
                yAxisIndex:0
            },
            {
                name:'脱硝效率',
                data: [],
                type: 'line',
                smooth:true,
                yAxisIndex:1
            }
    ]
};


export const option2_back ={
    dataZoom:[{
        type: 'inside',
        start: 90,
        end: 100
    }, {
        bottom:"0%", 
        handleIcon: 'M10.7,11.9v-1.3H9.3v1.3c-4.9,0.3-8.8,4.4-8.8,9.4c0,5,3.9,9.1,8.8,9.4v1.3h1.3v-1.3c4.9-0.3,8.8-4.4,8.8-9.4C19.5,16.3,15.6,12.2,10.7,11.9z M13.3,24.4H6.7V23h6.6V24.4z M13.3,19.6H6.7v-1.4h6.6V19.6z',
        handleSize: '80%',
        handleStyle: {
            color: '#fff',
            shadowBlur: 3,
            shadowColor: '#11111',
            shadowOffsetX: 2,
            shadowOffsetY: 2
        }
    }],
    title: {
        text: '1号格氨逃逸脱硝效率对比图',
        textStyle: {
            fontSize: 16,
            color: "#3e3e3e"
        },
        // padding:[15,80]
        left: "center",
        top: "0px"

    },
    tooltip: {
        trigger: 'axis',
        formatter: '{b}' +'<br/>'+ '{a0}: {c0}'+'ppm'+'<br/>'+'{a1}: {c1}'+'%'
    },
    legend: {
        data: ['氨逃逸', '脱硝效率'],
        left: "center",
        top: "20px"
    },
    xAxis: {
        type: 'category',
        data: [],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            },
            rotate: 45
        }
    },
     
    yAxis: [   
        {
            name:"氨逃逸(ppm)",
            gridIndex: 0,  
                      
                   
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false
            },
            scale:true,
            min:0,
            max:10
        },
        {
        name:"脱硝效率(%)",
        gridIndex:0,  
                      
           
        axisLabel: {
            show: true,
             formatter: '{value}%',
            textStyle: {
                color: '#3e3e3e'
            }
        },
        splitLine: {
            show: false
        },
        scale:true,
        min:0,
        max:100
		}]
        ,
    series: [{
                name:'氨逃逸',
                data: [],
                type: 'line',
                smooth:true,
                yAxisIndex:0
            },
            {
                name:'脱硝效率',
                data: [],
                type: 'line',
                smooth:true,
                yAxisIndex:1
            }
    ]
};