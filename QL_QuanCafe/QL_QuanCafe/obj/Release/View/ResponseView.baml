   M S B A M L   `   `   `  ���� F  BQL_QuanCafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QL_QuanCafe.ViewQL_QuanCafe.View  #    QL_QuanCafe.View.ResponseView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:QL_QuanCafe.View     X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  _ [MaterialDesignThemes.Wpf, Version=4.7.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  ResponseView��$	��565��$	��550�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�.���  � RowDefinitions �� $��25 ��� $��* �.+��� -    ��Name$ pnlControlBar��$��0�� �� Orientation$ 
Horizontal=�$��RightToLeft=�
������ $��0,0,5,0q�.+��� -    ��Name$ btnClose��   controlButton#��[   
 color4
 � Tag# [ .��!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Xmark=�  controlButtonIcon#��[ �� -   $ btnMinimize��#��[   
 color6# [ .��  $ WindowMinimize=�$��12��#��[ � $��1��$��	30 0 30 0q�	 � ColumnDefinitions	 �� $��* �.+�� $��0�� �� $��75 ��� $��75 ��� $��75 ��� $��75 ��� .+�� $��0��.+��� .+��� Họ và tên�� -   
 ��Name$
 tb_fullName��� $��1��.+��� .+��� Email�� -   $
 tb_email��� $��2��.+��� .+��� Số điện thoại�� -   $
 tb_phone��� $��3��.+��� .+��� Chủ đề�� -   $
 
tb_subject��� $��4��.+��� .+��� -   $
 tb_feedBackMessage��$	��Top=�$	��150�� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nội dung phản hồi��{���  �� Path$ 	IsChecked� �� ElementName$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� $ 
Horizontal=�$��Right=�$��0 30 0 0q�.+��� -	   $ btn_SendFeedBack�� # MaterialDesignRaisedLightButton#��[ $	��150�� � ToolTip$4 .Resource name: MaterialDesignRaisedLightButton�����#478778
����������#478778.��Gửi phản hồi�� -
   $ 
btn_Cancel��#��[ $	��100��$��20 0 0 0q�$4 .Resource name: MaterialDesignRaisedLightButton��.��Hủy