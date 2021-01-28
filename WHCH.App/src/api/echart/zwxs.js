export const zwxs_now=(flag,dt,d1,d2,d3)=>{
    let title_table = {"dg":"低温过热器","fgp": "分隔屏过热器", "hp": "后屏过热器", "mg": "末级过热器", "dz": "低温再热器", "gz": "高温再热器"};
    let ts=title_table[flag]+ "沾污程度";
    return {
        title: {
            text: ts,
            textStyle: {
                fontSize: 16,
                color: "#3e3e3e"
            },
            // padding:[15,80]
            left: "center",
            top: "15px"
    
        },
    
        tooltip: {
            trigger: 'axis',
            formatter: function (params) {               
                return "上限值：" + (params[0].value) + "<br>沾污程度:" + (params[1].value)+ "<br>下限值:" + (params[2].value);
            },
            axisPointer: {
                type: 'cross',
                label: {
                    backgroundColor: '#283b56',
                  
                },
            }
        },
        legend: {
            data: ['', ts, ''],
            x: "center",
            y: "40px",
    
            textStyle: {
                fontSize: 12,//字体大小
                color: '#3e3e3e'//字体颜色
            }
        },
        grid: {
            x: '10%',
            y: "70px",
            x1: '2%',
            y1: "40px",
    
        },
        xAxis: [
            {
                type: 'category',
                boundaryGap: true,
                data: dt,
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
                scale: true,
                // boundaryGap: [0.2, 0.2],
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#3e3e3e'
                    }
                },
                splitLine: {
                    show: false
                }
    
            }
        ],
       
        series: [
            {
                name: '',
                type: 'line',
                symbol: "none",
                areaStyle: {
                    // color:'rgba(0,255,0,0.4)'
                    color:'#9DE49d'
                },
                smooth: false,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',
                                color: 'blue'
    
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: d1
            },
            {
                name: ts,
                type: 'line',
                smooth: true,
                seriesLayoutBy: 'row',
                data: d2
            },
            {
                name: '',
                symbol: "none",
                areaStyle: {
                    color:'#C8DDC8',
                    opacity:1
                },
                type: 'line',
                smooth: false,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',
                                color: 'red'
                            }
                        }
                },
                data: d3
            }
        ]
    }
}



export const zwxs_now_back=(flag,dt,d1,d2,d3)=>{
    let title_table = {"dg":"低温过热器","fgp": "分隔屏过热器", "hp": "后屏过热器", "mg": "末级过热器", "dz": "低温再热器", "gz": "高温再热器"};
    let ts=title_table[flag]+ "沾污程度";
    return {
        toolbox: {
            feature: {
                saveAsImage: {}
            }
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

        title: {
            text: ts,
            textStyle: {
                fontSize: 16,
                color: "#3e3e3e"
            },
            // padding:[15,80]
            left: "center",
            top: "15px"
    
        },
    
        tooltip: {
            trigger: 'axis',
            formatter: function (params) {               
                return "上限值：" + (params[0].value) + "<br>沾污程度:" + (params[1].value)+ "<br>下限值:" + (params[2].value);
            },
            axisPointer: {
                type: 'cross',
                label: {
                    backgroundColor: '#283b56',
                  
                },
            }
        },
        legend: {
            data: ['', ts, ''],
            x: "center",
            y: "40px",
    
            textStyle: {
                fontSize: 12,//字体大小
                color: '#3e3e3e'//字体颜色
            }
        },
        grid: {
            x: '10%',
            y: "70px",
            x1: '2%',
            y1: "40px",
    
        },
        xAxis: [
            {
                type: 'category',
                boundaryGap: true,
                data: dt,
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
                scale: true,
                // boundaryGap: [0.2, 0.2],
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#3e3e3e'
                    }
                },
                splitLine: {
                    show: false
                }
    
            }
        ],
       
        series: [
            {
                name: '',
                type: 'line',
                symbol: "none",
                areaStyle: {
                    // color:'rgba(0,255,0,0.4)'
                    color:'#9DE49d'
                },
                smooth: false,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',
                                color: 'blue'
    
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: d1
            },
            {
                name: ts,
                type: 'line',
                smooth: true,
                seriesLayoutBy: 'row',
                data: d2
            },
            {
                name: '',
                symbol: "none",
                areaStyle: {
                    color:'#C8DDC8',
                    opacity:1
                },
                type: 'line',
                smooth: false,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',
                                color: 'red'
                            }
                        }
                },
                data: d3
            }
        ]
    }
}
