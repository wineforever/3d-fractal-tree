# Wineforever.Coordinate 函数说明

初始化：
Wineforever.Coordinate.client.Initialization();
可选参数：[AxisDim] 指示坐标系维度
[isRelative] 指示是否使用相对坐标
[isShowCoordinate] 指示是否绘制观察窗和坐标系
[CustomSize] 传入一个矩形，指示观察窗的左上角和右下角坐标。例如:CustomSize = new float[] { 10, 10, 600, 400 }

绘制点：
Wineforever.Coordinate.client.DrawPoint(X, Y);
可选参数: [brush] 选择画刷颜色
[Size] 绘制点的大小

绘制点集:
Wineforever.Coordinate.client.DrawPoints(points);
可选参数: [Color] 点颜色，例如"Red"
[Size] 点尺寸，注:该值越大效率越低

绘制直线:
Wineforever.Coordinate.client.DrawLine(W,b);
Wineforever.Coordinate.client.DrawLine(X0,Y0,X1,Y1,[isExtend]);
//设置直线是否延伸至画布边界

显示:
PictureBox.Image = Wineforever.Coordinate.client.Show();

设置原点坐标:
Wineforever.Coordinate.client.SetOriginalPoint(0,0); //默认原点坐标为(50,50)

设置背景色:
Wineforever.Coordinate.client.SetBackground(Brushes.White);

三维坐标系 - 绘制点:
Wineforever.Coordinate.client.DrawPoint(X, Y, Z);
可选参数: [Color] 点颜色，例如"Red"
[Size] 点尺寸，注:该值越大效率越低

三维坐标系 - 绘制点集:
Wineforever.Coordinate.client.DrawPoints(points);
可选参数: [Color] 点颜色，例如"Red"
[Size] 点尺寸，注:该值越大效率越低
[Complex] 精细度，注:该值越大效率越低
Wineforever.Coordinate.client.DrawPoints(points,colors);//绘制对应颜色的点集

三维坐标系 - 绘制圆:
Wineforever.Coordinate.client.DrawCircle(X0, Y0, Z0, nX, nY, nZ, R, Brushes.Red);
//（X,Y,Z）为圆心坐标,n为法线向量,R为半径
可选参数: [Size] 指示圆周线条粗细

三维坐标系 - 绘制圆柱:
Wineforever.Coordinate.client.DrawCylinder(X0, Y0, Z0, X1, Y1, Z1, R, Texture, Size, complex);
//(X0,Y0,Z0):起始点坐标,（X1,Y1,Z1)：终止点坐标,R:圆柱半径,Texture:贴图,
可选参数:[Size] 像素点粗细 
[complex] 图像精细度

三维坐标系 - 绘制圆台:
Wineforever.Coordinate.client.DrawCylinder(X0, Y0, Z0, X1, Y1, Z1, R0, R1, Texture, Size, complex);
//(X0,Y0,Z0):起始点坐标,（X1,Y1,Z1)：终止点坐标,R0:圆台起始半径,R1:圆台终止半径,Texture:贴图,
可选参数:[Size] 像素点粗细 
[complex] 图像精细度

三维坐标系 - 绘制矩形:
Wineforever.Coordinate.client.DrawCylinder(X0, Y0, Z0, X1, Y1, Z1, nX,nY,nZ, Texture, Size, complex);
//(X0,Y0,Z0):起始点坐标,（X1,Y1,Z1)：终止点坐标,(nX,nY,nZ):方向辅助点,Texture:贴图,
可选参数:[Size] 像素点粗细 
[complex] 图像精细度

三维坐标系 - 渲染:(仅对于DrawPoints函数有效)
Wineforever.Coordinate.client.Render();
//在对坐标系进行调整之后，无需再次调用绘制点命令，只需Render()即可将原先的点全部渲染出来
//例如:SetRotation(Value1, Value2, Value3);
            Render();
            drawbox.Image = Show();

三维坐标系 - 设置旋转角:
Wineforever.Coordinate.client.SetRotation(180,144,214);

三维坐标系 - 设置焦距:
Wineforever.Coordinate.client.SetDistance(10);

三维坐标系 - 设置坐标轴长度:
Wineforever.Coordinate.client.SetAxisLength(10);

清除屏幕：
Wineforever.Coordinate.client.Clear();

曲线拟合:
Wineforever.Coordinate.client.Fit(Points); 
//本函数提供了多种重载方式，使用者可以根据自己需要选择直接绘制出拟合曲线或者返回某点的估计值。
//采用的数学方法为拉格朗日插值定理。

更新说明:
(V1.1)修复了当点坐标值过大或过小时溢出的问题.
(V2.0)修正了绘制直线坐标不正确的问题,并新增了两点式的直线绘制方法.
(V2.0)新增了绘制三维坐标系的相关函数.
(V2.1)新增了绘制点集的函数，提升效率.
(V2.1)新增了Render函数，可以快速渲染三维点集.
(V2.1)新增了相关函数，可以快速绘制立体圆周,空间圆柱,空间矩形.
(V2.1)新增了设置背景色函数.
