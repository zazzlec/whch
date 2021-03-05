export default {
  /**
   * @description 配置显示在浏览器标签的title
   */
  title: '五河电厂智能燃烧系统',
  /**
   * @description token在Cookie中存储的天数，默认1天
   */
  cookieExpires: 7,
  /**
   * @description 是否使用国际化，默认为false
   *              如果不使用，则需要在路由中给需要在菜单中展示的路由设置meta: {title: 'xxx'}
   *              用来在菜单中显示文字
   */
  useI18n: false,
  /**
   * @description api请求基础路径
   */
  baseUrl: {
    //dev: 'http://localhost:54321/',
    //pro: 'http://localhost:54321/',
    dev: 'http://10.0.43.35:8092/',//测试
    pro: 'http://10.0.43.35:8092/',//测试
    // dev: 'http://132.0.6.21:5000/',//6号炉
   //  pro: 'http://132.0.6.21:5000/',//6号炉
    defaultPrefix:"api/v1/"
  },
  authUrl: {
    //dev: 'http://localhost:54321/api/oauth/auth',
    //pro: 'http://localhost:54321/api/oauth/auth'
    dev: 'http://10.0.43.35:8092/api/oauth/auth',//测试
    pro: 'http://10.0.43.35:8092/api/oauth/auth'//测试
      //dev: 'http://132.0.6.21:5000/api/oauth/auth',//6号炉
      //pro: 'http://132.0.6.21:5000/api/oauth/auth'//6号炉
  },
  /**
   * @description 默认打开的首页的路由name值，默认为home
   */
  homeName: 'home',
  /**
   * @description 需要加载的插件
   */
  plugin: {
    'error-store': {
      showInHeader: false, // 设为false后不会在顶部显示错误日志徽标
      developmentOff: true // 设为true后在开发环境不会收集错误信息，方便开发中排查错误
    }
  }
}
