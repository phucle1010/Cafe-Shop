   M S B A M L   `   `   `  ����F  BQL_QuanCafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QL_QuanCafe.ViewQL_QuanCafe.View  5      #    QL_QuanCafe.View.FoodItemView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:QL_QuanCafe.View     5      .��5	      � $	��100��6     � ColumnDefinitions  5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 
tbFoodName��5      $��14(�6(   $��Center=�66   $��Center=�6S   �� 5   
    �� CornerRadius$ 50��6   $��80��5      $��1��5      ._�5      �� -   5         ��Name$ 	foodImage��5      $��/Image/area-1.jpg��5      $
��0 10q�5      $
��Fill=�5       J� Clip 5      �� 5       �� RadiusX$ 10Q�6(    �� RadiusY$ 10Q�5   (    �� Rect$ 	0,0,80,80�5   (   5      5       �� 5!   
   -   5        $ tbFoodPrice��5!      $��2��6)   $��14(�69   $��Center=�6G   $��Center=�6d   �� 5#   
   -   5         ��Name$ btnUpdateFood��5#      $��3��5$      $��0q�5%      $��Cập nhật món ăn��5&      
�������$��13(�5(      $��
Montserrat)�5)      	 � Cursor$
	 Hand��5*      $��0q�5+      ��5,      �� 5-      
 �� 
TargetType"
 ��6   .�5.      ��  �� Property � �� �� Value �#47877863    �� Triggers 5/      P� 50       P� Property �@J�IsMouseOver P� Value . . �51      ��  � �� �#2AAA8A6;   52      54      ��56      �� 57       �� 
TargetType" ��6"   .R�58      �� $	��120��6   $��30��6)   $ 15��59   )   #��z��5:   )   ._�5;      �� $��Center=�6+   $��Center=�5<   7   5>      5?      5A      �� 5C   
   -   5        $ btnUpdateTip��5C      $��4��5D      $��0q�5E      $��Cập nhật công thức��5F      
�������$��13(�5H      $��
Montserrat)�5I      $
	 Hand��5J      $��0q�5K      ��5L      �� 5M      "
 ��6   .�5N      ��  � �� �#47877863    5O      P� 5P       �@J�IsMouseOver . . �5Q      ��  � �� �#2AAA8A6;   5R      5T      ��5V      �� 5W      " ��6"   .R�5X      �� $	��130��6   $��30��6)   $ 15��5Y   )   #��z��5Z   )   ._�5[      �� $��Center=�6+   $��Center=�5\   7   5^      5_      5a      5c      5d      