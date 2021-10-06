 
这个参考了微软的开源项目eShopOnWeb,DDD模式项目做大了也不会很乱，我自己平时做项目都是参考微软的规范来做的,很多基础代码我就直接拿过来复用了
1.在Web和PublicApi中配置数据库连接字符串
2.启动项设置在publishApi 完成 数据库迁移，执行 update-database -context ShopContext 和 update-database -context AppIdentityDbContext
3.仅仅实现了signalR的自动价格推送，只是测试而已。生产环境中 可以从后台推送(redis发布订阅或者Http方式)