# Hydro Map - 水文地理信息系统

## 项目简介

Hydro Map 是一个基于 [DotSpatial](https://dotspatial.github.io/) 框架开发的轻量级地理信息系统（GIS）应用程序，专门用于水文分析和地理数据处理。该项目集成了多个 DotSpatial 基础功能以及添加了两种专门的水文分析算法。

## 主要功能

### 🗺️ 地图显示与导航
- **多图层支持**：同时加载和显示矢量和栅格图层
- **地图导航工具**：缩放、平移、全图显示等基本导航功能
- **图层管理**：图例显示、图层开关、图层属性查看

### 📊 矢量数据处理
- **Shapefile 支持**：加载和显示点、线、面矢量数据
- **属性表操作**：查看、编辑、筛选矢量要素属性
- **要素选择**：交互式选择矢量要素
- **标签显示**：基于属性字段显示要素标签
- **随机颜色渲染**：为矢量要素分配随机颜色

### 🏔️ 栅格数据处理
- **DEM 数据支持**：加载和处理数字高程模型（TIFF格式）
- **栅格计算**：支持基本的栅格数学运算
- **重分类**：栅格值重分类功能
- **山体阴影**：生成山体阴影效果
- **颜色方案**：自定义栅格颜色渲染

### 🌊 水文分析工具
- **洼地填充**：自动填充DEM中的洼地
- **流向计算**：计算水流方向（D8算法）
- **平坦区域处理**：解决平坦区域的流向问题
- **河流网络提取**：基于流向数据提取河流网络
- **流域分析**：支持基本的流域划分功能

### 📐 空间分析工具
- **面积计算器**：计算多边形要素面积（平方米、平方公里、公顷）
- **投影管理器**：支持多种坐标系统投影转换
  - UTM NAD1983 Zone 12N
  - North America Albers Equal Area Conic
  - USA Contiguous Lambert Conformal Conic
  - Cylindrical Equal Area World
  - North Pole Azimuthal Equidistant
  - USA Contiguous Albers Equal Area Conic USGS
- **投影比较**：比较不同投影系统下的面积差异

### 🎨 制图与可视化
- **要素绘制**：创建点、线、面要素
- **路径绘制**：绘制徒步路径并提取高程剖面
- **地图打印**：支持地图打印功能
- **自定义样式**：设置字体、颜色、符号等样式

### 🔍 数据查询与分析
- **属性查询**：基于属性值筛选要素
- **数值筛选**：基于数值范围筛选要素
- **空间查询**：点击查询要素信息
- **数据导出**：支持分析结果导出

## 技术特性

- **多语言支持**：内置中文界面
- **GDAL 集成**：支持多种栅格格式
- **内存优化**：高效的内存管理
- **插件架构**：支持功能扩展
- **跨平台**：基于 .NET Framework

## 安装与使用

### 系统要求
- Windows 7/8/10/11
- .NET Framework 4.5 或更高版本
- 至少 2GB 内存
- 500MB 可用磁盘空间

### 安装方法

#### 方法一：使用安装包（推荐）
在 `install_Setup` 目录中提供了完整的安装包：
- `setup.exe` - 安装程序
- `Hydro_Map.msi` - Windows 安装包

运行 `setup.exe` 按照向导完成安装。
注意请新建一个文件夹同时确保安装路径为英文。

#### 方法二：源码编译
1. 使用 Visual Studio 打开 `Demo_Map.sln` 解决方案文件
2. 确保所有依赖库在 `libs` 文件夹中
3. 编译并运行项目

### 使用指南

1. **加载数据**：使用"文件"菜单加载矢量和栅格数据
2. **地图导航**：使用"地图"菜单进行缩放、平移等操作
3. **分析工具**：使用左侧工具面板进行各种空间分析
4. **投影管理**：使用投影管理器切换坐标系统
5. **结果导出**：将分析结果保存为文件

## 项目结构

```
Demo_Map-good/
├── Demo_Map/                 # 主项目源码
│   ├── Demo_Map/            # 核心应用程序
│   ├── Services/            # 服务类（面积计算、流向分析等）
│   ├── ProjectionExplorer/  # 投影管理模块
│   └── libs/               # 依赖库文件
├── Test_File/              # 测试数据
│   ├── D8_Tests/          # 流向分析测试数据
│   ├── Raster_Test/       # 栅格数据测试
│   ├── Vector_Test/       # 矢量数据测试
│   └── River_test/        # 河流分析测试
└── install_Setup/         # 安装包文件
    ├── setup.exe          # 安装程序
    └── Hydro_Map.msi         # Windows 安装包
```

## 开发环境

- **开发语言**：C#
- **框架**：.NET Framework 4.5+
- **GIS 库**：DotSpatial
- **栅格处理**：GDAL
- **开发工具**：Visual Studio 2019/2022

## 许可证

本项目基于开源许可证发布，具体许可证信息请参考项目根目录的 LICENSE 文件。

## 贡献指南

欢迎提交 Issue 和 Pull Request 来改进项目。在提交代码前，请确保：
1. 代码符合项目编码规范
2. 新功能包含适当的测试
3. 更新相关文档

## 致谢

特别感谢- **CYN** - 负责了label编辑功能和流域分析模块的提取河网功能

特别感谢以下测试人员的宝贵贡献：

- **WZ**
- **Rise**
- **Sky**  
- **ATA** 
- **Heeseun9_** 
- **Gemini** 

感谢所有为项目发展做出贡献的开发者和用户！

## 联系方式 
- **10230307@njnu.edu.cn**    
- **1523518721@qq.com**

如有问题或建议，请通过以下方式联系：
- 提交 GitHub Issue
- 发送邮件至项目维护者

---

*Hydro Map - 让水文地理分析更简单、更高效*
