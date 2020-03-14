### 3d-Fractal-Tree

#### Introduction

This project mainly introduces the image processing class library developed based on C# which can easily realize 3D image rendering, such as the 3D fractal tree.

I have made some sample programs in the **examples** folder. They show you the power of this library.

#### Examples

- 3D Fractal Tree

  This fractal tree is based on string substitution algorithm. In order to facilitate real-time calculation, I only did one iteration.

  ![](http://106.15.93.194/assets/3d-fractal-tree.gif)

- Julia Set

  This Julia set is based on time escape algorithm. I could have implemented it through the functions of the class library, but in order to pursue rendering efficiency, I chose to use the pointer operation bitmap method. For the functions of the class library, I only use the color rendering part.

  ![](http://106.15.93.194/assets/Julia-set.png)

- Background Denoising

  This uses a function to deal with background noise. In order to use, you must prepare a background image in advance, otherwise the program will throw an error. It will call your camera and capture the target object in front of the background. You can set the mask color for the background or the target object.
  
  ![](http://106.15.93.194/assets/background-denoising.gif)
  
- Text Segmentation

  You can also use it for text segmentation, which will make the preprocessing of text recognition very simple. It's more than that. You can detect objects in real time by using histogram statistical function and background filtering.

  ![](http://106.15.93.194/assets/text-segmentation.png)

#### How to use

Just like the general use of C# class library, you can learn about it by following these steps:

1. Put **Wineforever.Coordinate.dll** in the program root directory.

2. Read **Manual.txt** if necessary.

3. Import **Wineforever.Coordinate.dll** and reference namespace:

   ```C#
   using Wineforever.Coordinate;
   ```

4. Initialization during program load:

   ```C#
   Wineforever.Coordinate.client.Initialization();
   ```

5. Do something...

   ```C#
   Wineforever.Coordinate.client.DrawPoint(3, 4);
   ```

6. Render:

   ```C#
   PictureBox.Image = Wineforever.Coordinate.client.Render();
   ```

The program provides 2D and 3D initialization methods. When drawing in 3D mode, all results will be programmed in 3D, so is 2D.

Functions can be roughly divided into two categories: Draw and Handle. For a Draw function, it operates on the canvas. For Handle functions, it usually returns an Bitmap.

#### Principle

I will briefly describe the mathematical principles of some algorithms of this class library.

For example, for the creation of a 3D coordinate system, it is based on one of the following matrices:

![](http://106.15.93.194/assets/Mathematical-principle-of-3D-coordinate-system.png)

The rotation matrix R I used in the program is based on Euler angle:

![](http://106.15.93.194/assets/Euler-angle-matrix.png)

You can also choose other rotation matrices.

In the program, the drawing algorithm of the space circle is also implemented. As shown in the fractal tree, it is mainly based on the parameter equation of the space circle:

![](http://106.15.93.194/assets/Circular-equation-of-space.png)

Some other algorithms will not be explained here. because of their mathematical principles are simple.

#### Agreement

This class library follows the open source protocol and is allowed to be used commercially but the premise is that my class library must be specified in the source code.

#### Donate

If you want to sponsor me, you can scan the QR code below,or donate bitcoin to me. Thank you for your support anyway.

![](http://106.15.93.194/donate/donate.png)

Bitcoin Wallet:16RpsEY6C1zLZTPZUX8mXK9ozooqhh5YqS

