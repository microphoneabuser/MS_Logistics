   M S B A M L   `   `   `  ����F  BNTI_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NTI_projectNTI_project  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      E ADragablz, Version=0.0.3.223, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz 5
      *    $NTI_project.StoremanAllOrdersControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:NTI_project     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      0sys&clr-namespace:System;assembly=mscorlib  5	      7dragablz(clr-namespace:Dragablz;assembly=Dragablz  5
      X	 TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5      ���	#FF2D2D30.��5      �   � ColumnDefinitions  5   
   �� 5      �� 5      .+�5   
   � $��2��6   .+�5      � ���	#FFAEAEAE$��-3q�6*   .+�5      �� $��9q�6   ���	#FF2A2E32 �� Padding$ 30q�6;    �� CornerRadius$ 10��6H    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6+      Color$ DarkSlateGray��6;      ShadowDepth$ 0Q�6Q   ._�5      �� -   5         ��Name$ 	HomePanel��5   !   $	��-10q�64   .+�5      � .+�5      �� -   5         ��Name$ mainText��5   (   $��20(�6:   $
��Bold"�6H   
�������$5��/Посылки принятые на склад��6m   $
��Left=�6�   $��Center=�6�   $��10q�6�   �� 5      -   5        	 ��Name$	 UpdateButton��5   %    .  *MaterialDesignFloatingActionMiniDarkButton#��[  6;   $��Center=�6   $��	828,8,0,9q�6�   $��30��6�   $��30��6�   ���	#FF5B5B5B���	#99151C23
 �� 	ClickMode$
 Release=�6  $
��Left=�6  .��5   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Update=�6:   $��20��6H   $��20��6T   $��0q�6_   5      5      �� 5       -   5         ��Name$
 text��5    "    �� TextWrapping$
 Wrap=�60    �� AcceptsReturn .  �� 
IsReadOnly . $��15(�6k   $��Light"�6y   
�������$����На данной странице отображен список посылок, которые нужно укомплектовать. Чтобы взять посылку для последующей комплектации отметьте соответствующую. После того, как вы выберите все нужные посылки нажмите на кнопку "Перейти к комплектации".��6�   $
��Left=�6�  $��Center=�6�  $	��958��6�  �� 5!      -   5        $ 	GridPanel��5!   %   $y�Visible=�68   .+�5"      �� $	��504��6)   $��	0 10 0 10q�66   .+�5#   "   &   System.Windows.Controls.DataGrid  -   5          Name$ 
OrdersGrid��5#   +   $	��504��6]      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserResizeColumns .     ClipboardCopyMode$ IncludeHeader=�5%   +      
IsReadOnly .    AutoGenerateColumns .     GridLinesVisibility$	 All=�5&   G      HeadersVisibility$ Column=�6a    J� IsHitTestVisible . ���	#FF303438��5#   ?   �� *Items+   Columns 5(   &   0  *System.Windows.Controls.DataGridTextColumn  5)   *   ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6Z      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
OrderNum+6x     5*   *   $ Вес (кг)��6X   $
 Auto 6j    6=   �� *Weight+6y     5+   *   $ Размеры (м)��6V   $
 Auto 6k    6=   �� *Size+6z     5,   *   $' !Параметры посылки��6]   $	 300 6x    6=   �� *AddServices+    ElementStyle  5-   .   �� 5.   2   ! �� 
TargetType"! ��68   .�5/   6   �� " �� Property" � ��# �� Value$
# Wrap=�6U   50   3   52   +     53   *   $ Дата доставки��6V   $
 Auto 6m    6=   �� *Date+6|     54   *   $! Время доставки��6V   $
 Auto 6n    6=   �� *Time+6}   4  .System.Windows.Controls.DataGridTemplateColumn  55   *   $   CellTemplate$ 56   .   �� 57   2   .R�58   6   �� $��
checkOrder��6o   -   5          MaterialDesignCheckBox#��[ 58   ?   $.��(Взять на комплектацию��59   =   ���	#FF3388EA���	#7F1976D2
�������6�   5:   3   5<   +   5>   #   5@      �� 5A      $��5q�6)   .+�5B   "   �� -   5        $	 ToProcessingButton��5B   )   $0��*Перейти к комплектации��6E      MaterialDesignOutlinedButton#��[ 6f   $
 Release=�6�   6�   5C      5D      5E      5F      5G      5H      �� 5I   
   -	   5        $��
loadborder��5I      $��411,263.5,411,263.5q�6#   $��2��6@   ���	#FF00A2FF$��1q�6l   $ 3��6�   $y�Hidden=�6�   ._�5J      �� -
   5        $��
LoadingGif��5J   a   "	  WpfAnimatedGif.ImageBehavior% 	  AnimatedSource$/% )pack://application:,,,/Images/loading.gif��6   $��Center=�6s   $��Center=�6�   $��2��6�   5K      5L      5N      