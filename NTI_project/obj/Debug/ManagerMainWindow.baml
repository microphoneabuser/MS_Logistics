   M S B A M L   `   `   `  ����F  BNTI_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NTI_projectNTI_project  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   #    NTI_project.ManagerMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:NTI_project     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   $	��800��5	      $
��1080��6'   
�������  � WindowStartupLocation$  CenterScreen=�6G    � WindowStyle$
 None=�6l    � 
ResizeMode$ CanMinimize=�6    � 	Resources 5
         phoneNumber_AsInt32  phoneNumber_AsString  OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	      &	 >     &	     ��5   
   5452626��69   ��5   
   5452626��6;   �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 70Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 ButtonOpenMenu��66   .[�5      �� #��[ 6   5      :� 5   
   $	 ButtonBase.Click��6   $
 ButtonCloseMenu��66   .[�5      �� #��[ 6   5       .��5#      � ���	#FFDEDEDE.+�5$   
   � -   5         �Name$ Up��5$       � RowDefinitions 5%      �� 5&      $��25 �6    6.   .+�5(      � -   5        $��Toolbar��5(      $��0��6"   ���	#FF2D2D30$��0q�6F   $	��Top=�6Q   .+�5)      � -   5         �Name$ Dragger��5)      $��Center=�6+   
������� J� Opacity$	 0.2Q�6U    � Points% �    z  �  Bp* �  T�*$��180,0q�5-      $	��720��6(   5.      �� 5/       �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�50      �� -   5        $��minus_Button��50      ._�51      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�62   $��16��6?   $��16��6K   $��5q�6V   
������ ���	#FF9191916z   52      �� 53      -   5        $��recover_Button��53      ._�54        $ SquareOutline=�62   $��15��6G   $��15��6S   $��5,4.5,5,4.5q�6^   
������ ���	#FF919191$��Stretch=�6�   55      �� 56      -   5        $��close_Button��56      ._�57        $ Close=�62   $
��Auto��6?   $��19��6M   $��3,3,5,3q�6X   
������ ���	#FF919191$��Stretch=�6�   58      59      5:      5;      � 5<   
   -   5        $ GridMain��5<      $��Stretch=�6!   $��Stretch=�6?   ���	#FF2D2D30$��	70,85,0,0q�6r   � 5=   
   $��60��6   $	��Top=�6   ���	#FF2D2D30$��0 25 0 0q�6J    J� Effect 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�5A      �� $ 
Horizontal=�6   $��Right=�62   .+�5B      '  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen .  $��10q�6e      PopupContent. 5C      �� $	��150��6!   .+�5D      �� -   5        $!��Личный кабинет��5D   !   6:   �� 5E      �� 5F      -	   5        $��
Выйти��5F   !   61   5G      5H      5I      �� 5J      $��Center=�6   $��Center=�65   $��22(�6P   $��MS Logistics Manager��6^   5K      � 5L   
   -
   5        $ GridMenu��5L      $��70��6!   $
��Left=�6,   ���	#FF2D2D30$��0 25 0 0q�6^    5M        5N      $ 2Q�6#   $ 1Q�62   $ 	#FFAEAEAE��6B   .+�5P      �� .+�5Q      � $��65��6   ���	#FF2D2D30 J� RenderTransformOrigin$ 0.5,0.5&�6:   z�5R      V� 5S      .~�5T      �� �� 5U      �� 5V      T� 5W      5X      .+�5Z      �� -   5         ��Name$ ButtonOpenMenu��5Z      $��60��65   $��60��6A   $��5q�6L   $��Right=�6W   $	��Top=�6s    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5[        $
 Menu=�62   $��25��6>   $��25��6I   5\      �� 5]      -   5        $ ButtonCloseMenu��5]      $y�	Collapsed=�66   $��60��6M   $��60��6Y   $��5q�6d   $��Right=�6o   $	��Top=�6�   #��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5^        $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5_      �� 5a      $��80��6   $��Bottom=�6(   5b      �� 5c      -   5         ��Name$ ListViewMenu��5c      ���	#FF5C99D6$��Disabled=�6H   ���	#FF2D2D30.@�5d      �� -   5         ��Name$ 	NewOrders��5d   #   $��60��66   .��5e      �� $ 
Horizontal=�6%   .+�5f        $ ClipboardList=�66   $��25��6K   $��25��6W   $��10q�6b   �� 5g      $%��Свободные заявки��6(   $��Center=�6@   $��20 10q�6[   5h      5i      �� 5j      -   5        $ ProcessingOrders��5j   #   $��60��6=   .��5k      �� $ 
Horizontal=�6%   .+�5l        $ PlaylistEdit=�66   $��25��6J   $��25��6V   $��10q�6a   �� 5m      $��На обработке��6(   $��Center=�6<   $��20 10q�6W   5n      5o      �� 5p      -   5        $ MyOrders��5p   #   $��60��65   .��5q      �� $ 
Horizontal=�6%   .+�5r        $ History=�66   $��25��6E   $��25��6Q   $��10q�6\   �� 5s      $��Мои заказы��6(   $��Center=�6:   $��20 10q�6U   5t      5u      �� 5v      -   5        $ Messages��5v   #   $��60��65   .��5w      �� $ 
Horizontal=�6%   .+�5x        $ Message=�66   $��25��6E   $��25��6Q   $��10q�6\   �� 5y      $��Сообщения��6(   $��Center=�69   $��20 10q�6U   5z      5{      5|      5}      5~      5      5�      