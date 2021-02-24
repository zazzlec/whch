
export const noxdata = {
    title: {
        text: "主汽温度",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    tooltip: {
        t1:0,
        y:9,
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            crossStyle: {
                color: '#999'
            }
        },
        formatter:function(a) {
            // console.log(JSON.stringify(a));
            // let t=0;
            return '时间: '+a[0].name+'<br/>'+'主汽温度: '+a[0].value ;
        }
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
        axisLabel:{
            interval:10,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
    },
    series: [{
        data: [],
        type: 'line',smooth: true,
        showSymbol: false
    }]
}

export const n2_1 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    legend: {
        data: ['正平衡效率', '反平衡效率']
    },
    // tooltip: {
    //     position: 'right'
    // },
    tooltip: {
        trigger: 'axis',
        formatter:function(a) {
            console.log(JSON.stringify(a));
            // let t=0;
            return '时间: '+a[0].axisValue+'<br/>'+''+a[0].seriesName+': '+ parseFloat(a[0].value).toFixed(2)+'%'+'<br/>'+''+a[1].seriesName+': '+ parseFloat(a[1].value).toFixed(2)+'%' ;
        }
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
        axisLabel:{
            interval:6,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
    },
    series: [{
        name:"正平衡效率",
        data: [],
        // showSymbol: false,
        // symbol: 'none', //取消折点圆圈
        showSymbol: false,
        type: 'line',
        smooth: true,
        emphasis: {
            focus: 'series'
        }
    },{
        name:"反平衡效率",
        // showSymbol: false,
        // symbol: 'none', //取消折点圆圈
        showSymbol: false,
        data: [],
        type: 'line',
        smooth: true,
        emphasis: {
            focus: 'series'
        }
    }]
}

export const n2_2 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    legend: {
        data: ['左墙沸下温度', '右墙沸下温度','右墙沸上温度','前墙#1沸上温度','前墙#2沸上温度','前墙#3沸上温度','右墙沸中温度']
    },
    tooltip: {
        trigger: 'axis',
        // formatter:function(a) {
        //     console.log(JSON.stringify(a));
        //     return '时间: '+a[0].axisValue+'<br/>'+''+a[0].seriesName+': '+ parseFloat(a[0].value).toFixed(2)+'%'+'<br/>'+''+a[1].seriesName+': '+ parseFloat(a[1].value).toFixed(2)+'%' ;
        // }
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
        axisLabel:{
            interval:6,
            rotate:40
        }
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [
    {
        name:"左墙沸下温度",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },
    {
        name:"右墙沸下温度",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },
    {
        name:"右墙沸上温度",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },
    {
        name:"前墙#1沸上温度",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },
    {
        name:"前墙#2沸上温度",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },
    {
        name:"前墙#3沸上温度",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },
    {
        name:"右墙沸中温度",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    }
    ]
}

export const n2_3_1 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    legend: {
        data: ['低温过热器壁温1', '低温过热器壁温2','低温过热器壁温3','低温过热器壁温4']
    },
    tooltip: {
        trigger: 'axis',
        // formatter:function(a) {
        //     console.log(JSON.stringify(a));
        //     return '时间: '+a[0].axisValue+'<br/>'+''+a[0].seriesName+': '+ parseFloat(a[0].value).toFixed(2)+'%'+'<br/>'+''+a[1].seriesName+': '+ parseFloat(a[1].value).toFixed(2)+'%' ;
        // }
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
        axisLabel:{
            interval:6,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [{
        name:"低温过热器壁温1",
        data: [],
        showSymbol: false,
        smooth: true,
        type: 'line'
    },{
        name:"低温过热器壁温2",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },{
        name:"低温过热器壁温3",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },{
        name:"低温过热器壁温4",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    }]
}

export const n2_3_2 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    legend: {
        data: ['屏式过热器壁温1', '屏式过热器壁温2','屏式过热器壁温3','屏式过热器壁温4']
    },
    tooltip: {
        trigger: 'axis',
        // formatter:function(a) {
        //     console.log(JSON.stringify(a));
        //     return '时间: '+a[0].axisValue+'<br/>'+''+a[0].seriesName+': '+ parseFloat(a[0].value).toFixed(2)+'%'+'<br/>'+''+a[1].seriesName+': '+ parseFloat(a[1].value).toFixed(2)+'%' ;
        // }
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
        axisLabel:{
            interval:6,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [{
        name:"屏式过热器壁温1",
        data: [],
        showSymbol: false,
        smooth: true,
        type: 'line'
    },{
        name:"屏式过热器壁温2",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },{
        name:"屏式过热器壁温3",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },{
        name:"屏式过热器壁温4",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    }]
}

export const n2_3_3 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    legend: {
        data: ['高温过热器壁温1', '高温过热器壁温2','高温过热器壁温3','高温过热器壁温4']
    },
    tooltip: {
        trigger: 'axis',
        // formatter:function(a) {
        //     console.log(JSON.stringify(a));
        //     return '时间: '+a[0].axisValue+'<br/>'+''+a[0].seriesName+': '+ parseFloat(a[0].value).toFixed(2)+'%'+'<br/>'+''+a[1].seriesName+': '+ parseFloat(a[1].value).toFixed(2)+'%' ;
        // }
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
        axisLabel:{
            interval:6,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [{
        name:"高温过热器壁温1",
        data: [],
        showSymbol: false,
        smooth: true,
        type: 'line'
    },{
        name:"高温过热器壁温2",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },{
        name:"高温过热器壁温3",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    },{
        name:"高温过热器壁温4",
        showSymbol: false,
        smooth: true,
        data: [],
        type: 'line'
    }]
}


export const n4_1 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    // legend: {
    //     //data: ['污染率待吹灰上限', '污染率执行上限']
    //     data: ['污染率']
    // },
    tooltip: {
        t1:0,
        y:9,
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            crossStyle: {
                color: '#999'
            }
        },
        formatter:function(a) {
            let t=a[0].data;
            // console.log(JSON.stringify(a));
            return '污染率: '+t+'<br/>'+'污染率待吹灰上限: '+n4_1.tooltip.t1+'<br/>'+'污染率执行上限: '+n4_1.tooltip.y
        }
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
        axisLabel:{
            interval:2,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [
    {
        name:"污染率",
        data: [],
        showSymbol: false,
        smooth: true,
        type: 'line'
    },
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"#3398DB"
                },
                label:{
                    position:'middle',
                    formatter:"污染率待吹灰上限"
                },
                name: '污染率待吹灰上限',
                yAxis: 90
            }
            ]
        }
    }
    ,
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"rgba(238, 33, 33)"
                },
                label:{
                    position:'middle',
                    formatter:"污染率执行上限"
                },
                name: '污染率执行上限',
                yAxis: 80
            }
            ]
        }
    }
    ]
}

export const n4_2 = {
    
        title: {
            text: "",
            left: 'center',
            textStyle: {
                fontSize: 18,
                color: "#3e3e3e"
            },
            top:15
        },
        // legend: {
        //     //data: ['污染率待吹灰上限', '污染率执行上限']
        //     data: ['污染率']
        // },
        tooltip: {
            t1:0,
            y:9,
            trigger: 'axis',
            axisPointer: {
                type: 'cross',
                crossStyle: {
                    color: '#999'
                }
            },
            formatter:function(a) {
                let t=a[0].data;
                // console.log(JSON.stringify(a));
                return '污染率: '+t+'<br/>'+'污染率待吹灰上限: '+n4_2.tooltip.t1+'<br/>'+'污染率执行上限: '+n4_2.tooltip.y
            }
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
            axisLabel:{
                interval:2,
                rotate:40
            },
            type: 'category',
            data: []
        },
        yAxis: {
            type: 'value',
            scale:true
        },
        series: [{
            name:"污染率",
            data: [],
            showSymbol: false,
            smooth: true,
            type: 'line'
        },
        {
            showSymbol: false,
            type: 'line',smooth: true,
            markLine : {
                symbol:"none",               //去掉警戒线最后面的箭头
                data : [{
                    silent:false,             //鼠标悬停事件  true没有，false有
                    lineStyle:{               //警戒线的样式  ，虚实  颜色
                        type:"solid",
                        color:"#3398DB"
                    },
                    label:{
                        position:'middle',
                        formatter:"污染率待吹灰上限"
                    },
                    name: '污染率待吹灰上限',
                    yAxis: 90
                }
                ]
            }
        }
        ,
        {
            showSymbol: false,
            type: 'line',smooth: true,
            markLine : {
                symbol:"none",               //去掉警戒线最后面的箭头
                data : [{
                    silent:false,             //鼠标悬停事件  true没有，false有
                    lineStyle:{               //警戒线的样式  ，虚实  颜色
                        type:"solid",
                        color:"rgba(238, 33, 33)"
                    },
                    label:{
                        position:'middle',
                        formatter:"污染率执行上限"
                    },
                    name: '污染率执行上限',
                    yAxis: 80
                }
                ]
            }
        }
        ]
}

export const n4_3 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    // legend: {
    //     //data: ['污染率待吹灰上限', '污染率执行上限']
    //     data: ['污染率']
    // },
    tooltip: {
        t1:0,
        y:9,
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            crossStyle: {
                color: '#999'
            }
        },
        formatter:function(a) {
            let t=a[0].data;
            // console.log(JSON.stringify(a));
            return '污染率: '+t+'<br/>'+'污染率待吹灰上限: '+n4_3.tooltip.t1+'<br/>'+'污染率执行上限: '+n4_3.tooltip.y
        }
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
        axisLabel:{
            interval:2,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [{
        name:"污染率",
        data: [],
        showSymbol: false,
        smooth: true,
        type: 'line'
    },
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"#3398DB"
                },
                label:{
                    position:'middle',
                    formatter:"污染率待吹灰上限"
                },
                name: '污染率待吹灰上限',
                yAxis: 90
            }
            ]
        }
    }
    // ,
    // {
    //     showSymbol: false,
    //     type: 'line',smooth: true,
    //     markLine : {
    //         symbol:"none",               //去掉警戒线最后面的箭头
    //         data : [{
    //             silent:false,             //鼠标悬停事件  true没有，false有
    //             lineStyle:{               //警戒线的样式  ，虚实  颜色
    //                 type:"solid",
    //                 color:"rgba(238, 33, 33)"
    //             },
    //             label:{
    //                 position:'middle',
    //                 formatter:"污染率执行上限"
    //             },
    //             name: '污染率执行上限',
    //             yAxis: 80
    //         }
    //         ]
    //     }
    // }
    ]
}

export const n5_1 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    tooltip: {
        t1:0,
        y:9,
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            crossStyle: {
                color: '#999'
            }
        },
        formatter:function(a) {
            let t=a[0].data;
            return '堵塞率: '+t+'<br/>'+'堵塞率待吹灰上限: '+n5_1.tooltip.t1+'<br/>'+'堵塞率执行上限: '+n5_1.tooltip.y
        }
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
        axisLabel:{
            interval:2,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [{
        name:"污染率",
        data: [],
        showSymbol: false,
        smooth: true,
        type: 'line'
    },
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"#3398DB"
                },
                label:{
                    position:'middle',
                    formatter:"堵塞率待吹灰上限"
                },
                name: '堵塞率待吹灰上限',
                yAxis: 90
            }
            ]
        }
    }
    ,
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"rgba(238, 33, 33)"
                },
                label:{
                    position:'middle',
                    formatter:"堵塞率执行上限"
                },
                name: '堵塞率执行上限',
                yAxis: 80
            }
            ]
        }
    }
    ]
}

export const n5_2 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    tooltip: {
        t1:0,
        y:9,
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            crossStyle: {
                color: '#999'
            }
        },
        formatter:function(a) {
            let t=a[0].data;
            return '堵塞率: '+t+'<br/>'+'堵塞率待吹灰上限: '+n5_2.tooltip.t1+'<br/>'+'堵塞率执行上限: '+n5_2.tooltip.y
        }
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
        axisLabel:{
            interval:2,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [{
        name:"污染率",
        data: [],
        showSymbol: false,
        smooth: true,
        type: 'line'
    },
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"#3398DB"
                },
                label:{
                    position:'middle',
                    formatter:"堵塞率待吹灰上限"
                },
                name: '堵塞率待吹灰上限',
                yAxis: 90
            }
            ]
        }
    }
    ,
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"rgba(238, 33, 33)"
                },
                label:{
                    position:'middle',
                    formatter:"堵塞率执行上限"
                },
                name: '堵塞率执行上限',
                yAxis: 80
            }
            ]
        }
    }
    ]
}

export const n5_3 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    tooltip: {
        t1:0,
        y:9,
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            crossStyle: {
                color: '#999'
            }
        },
        formatter:function(a) {
            let t=a[0].data;
            return '堵塞率: '+t+'<br/>'+'堵塞率待吹灰上限: '+n5_3.tooltip.t1+'<br/>'+'堵塞率执行上限: '+n5_3.tooltip.y
        }
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
        axisLabel:{
            interval:2,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [{
        name:"污染率",
        data: [],
        showSymbol: false,
        smooth: true,
        type: 'line'
    },
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"#3398DB"
                },
                label:{
                    position:'middle',
                    formatter:"堵塞率待吹灰上限"
                },
                name: '堵塞率待吹灰上限',
                yAxis: 90
            }
            ]
        }
    }
    ,
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"rgba(238, 33, 33)"
                },
                label:{
                    position:'middle',
                    formatter:"堵塞率执行上限"
                },
                name: '堵塞率执行上限',
                yAxis: 80
            }
            ]
        }
    }
    ]
}

export const n5_4 = {
    title: {
        text: "",
        left: 'center',
        textStyle: {
            fontSize: 18,
            color: "#3e3e3e"
        },
        top:15
    },
    tooltip: {
        t1:0,
        y:9,
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            crossStyle: {
                color: '#999'
            }
        },
        formatter:function(a) {
            let t=a[0].data;
            return '堵塞率: '+t+'<br/>'+'堵塞率待吹灰上限: '+n5_4.tooltip.t1+'<br/>'+'堵塞率执行上限: '+n5_4.tooltip.y
        }
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
        axisLabel:{
            interval:2,
            rotate:40
        },
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value',
        scale:true
    },
    series: [{
        name:"污染率",
        data: [],
        showSymbol: false,
        smooth: true,
        type: 'line'
    },
    {
        showSymbol: false,
        type: 'line',smooth: true,
        markLine : {
            symbol:"none",               //去掉警戒线最后面的箭头
            data : [{
                silent:false,             //鼠标悬停事件  true没有，false有
                lineStyle:{               //警戒线的样式  ，虚实  颜色
                    type:"solid",
                    color:"#3398DB"
                },
                label:{
                    position:'middle',
                    formatter:"堵塞率待吹灰上限"
                },
                name: '堵塞率待吹灰上限',
                yAxis: 90
            }
            ]
        }
    }
    // ,
    // {
    //     showSymbol: false,
    //     type: 'line',smooth: true,
    //     markLine : {
    //         symbol:"none",               //去掉警戒线最后面的箭头
    //         data : [{
    //             silent:false,             //鼠标悬停事件  true没有，false有
    //             lineStyle:{               //警戒线的样式  ，虚实  颜色
    //                 type:"solid",
    //                 color:"rgba(238, 33, 33)"
    //             },
    //             label:{
    //                 position:'middle',
    //                 formatter:"堵塞率执行上限"
    //             },
    //             name: '堵塞率执行上限',
    //             yAxis: 80
    //         }
    //         ]
    //     }
    // }
    ]
}