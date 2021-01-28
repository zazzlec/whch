
var seriesLabel = {
    normal: {
        show: true,
        textBorderColor: '#333',
        textBorderWidth: 2
    }
}
export const fxoption={

    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'shadow'
        }
    },
    legend: {
        data: ['百分比（基础工况）', '百分比（实际工况）'],
        left: "center",
        top: "-5px"
    },
    grid: {
        left: 80,
        top:20
    },
    toolbox: {
        show: true,
        feature: {
            saveAsImage: {}
        }
    },
    xAxis: {
        type: 'value',
        name: 'Days',
        axisLabel: {
            formatter: '{value}'
        }
    },
    yAxis: {
        type: 'category',
        inverse: true,
        data: ['Sunny', 'Cloudy', 'Showers']
    },
    series: [
        {
            name: '百分比（基础工况）',
            type: 'bar',
            data: [],
            label: seriesLabel
        },
        {
            name: '百分比（实际工况）',
            type: 'bar',
            label: seriesLabel,
            data: []
        }
    ]
};

export const fxoption_back={
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'shadow'
        }
    },
    legend: {
        data: ['百分比（基础工况）', '百分比（实际工况）'],
        left: "center",
        top: "-5px"
    },
    grid: {
        left: 80,
        top:20
    },
    toolbox: {
        show: true,
        feature: {
            saveAsImage: {}
        }
    },
    xAxis: {
        type: 'value',
        name: 'Days',
        axisLabel: {
            formatter: '{value}'
        }
    },
    yAxis: {
        type: 'category',
        inverse: true,
        data: ['Sunny', 'Cloudy', 'Showers']
    },
    series: [
        {
            name: '百分比（基础工况）',
            type: 'bar',
            data: [],
            label: seriesLabel
        },
        {
            name: '百分比（实际工况）',
            type: 'bar',
            label: seriesLabel,
            data: []
        }
    ]
};

export const fxoption2={
    title: [{
        subtext: '基础工况占比',
        left: '25%',
        top: '66%',
        textAlign: 'center'
    }, {
        subtext: '实际工况占比',
        left: '75%',
        top: '66%',
        textAlign: 'center'
    }],
    tooltip: {
        trigger: 'item',
        formatter: '{b} :  {d}%'
    },
    series: [{
        type: 'pie',
        radius: '50%',
        center: ['25%', '35%'],
        data: [],
        animation: false,
        label: {
            position: 'outer',
            alignTo: 'none',
            bleedMargin: 5
        },
        left: 0,
        right: '66.6667%',
        top: 0,
        bottom: 0
    }, {
        type: 'pie',
        radius: '50%',
        center: ['75%', '35%'],
        data: [],
        animation: false,
        label: {
            position: 'outer',
            alignTo: 'labelLine',
            bleedMargin: 5
        },
        left: '33.3333%',
        right: '33.3333%',
        top: 0,
        bottom: 0
    }]
};

export const fsoption={
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            label: {
                backgroundColor: '#283b56'
            }
        },
        formatter: function (params) {
            return "硫化氢H2s : " + (params[0].value) ;
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
    
    xAxis: {
        type: 'category',
        data: []
    },
    yAxis: {
        type: 'value'
    },
    series: [{
        data: [],
        type: 'line',
        smooth: true
    },
    {
      name: '',
      symbol:'none',
      areaStyle: {
          color:'#eeee55',
          opacity:1
      },
      type: 'line',
      smooth: true,
      data: [],
      itemStyle: {
          normal:
              {
                  lineStyle: {
                      width: 0,
                      type: 'dotted',
                   
                  }
              }
      },
    },
    {
      name: '',
      symbol:'none',
      areaStyle: {
          color:'#90EE90',
          opacity:1
      },
      type: 'line',
      smooth: true,
      data: [],
      itemStyle: {
          normal:
              {
                  lineStyle: {
                      width: 0,
                      type: 'dotted',
                   
                  }
              }
      },
    }
  ]
};
