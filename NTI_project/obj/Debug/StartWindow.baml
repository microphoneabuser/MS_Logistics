   M S B A M L   `   `   `  ����F  BNTI_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NTI_projectNTI_project  5   	       NTI_project.StartWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5   	   %localclr-namespace:NTI_project  5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  StartWindow��5
   	   $	��600��6   $
��1080��6*    � WindowStartupLocation$ CenterScreen=�67    � WindowStyle$
 None=�6\    � 
ResizeMode$ CanMinimize=�6o   .��5      � ���	#FFAEAEAE � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   � -   5         �Name$ Up��5      $��2��6    � RowDefinitions 5      �� 5      $��25 �6    6.   .+�5      � -   5        $��Toolbar��5      $��0��6"   ���	#FF2D2D30$��0q�6F   $	��Top=�6Q   .+�5      � -   5         �Name$ Dragger��5      $��Center=�6+   
������� J� Opacity$	 0.2Q�6U   	 � Points%	 �    z  �  Bp* �  T�*$��180,0q�5      $	��720��6(   5      �� 5      
 �� Orientation$
 
Horizontal=�6   $��Right=�66   .+�5      �� -   5        $��minus_Button��5      ._�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�62   $��16��6?   $��16��6K   $��5q�6V   
������ ���	#FF9191916z   5      �� 5      -   5        $��recover_Button��5      ._�5         $ SquareOutline=�62   $��15��6G   $��15��6S   $��5,4.5,5,4.5q�6^   
������ ���	#FF919191$��Stretch=�6�   5!      �� 5"      -   5        $��close_Button��5"      ._�5#        $ Close=�62   $
��Auto��6?   $��19��6M   $��3,3,5,3q�6X   
������ ���	#FF919191$��Stretch=�6�   5$      5%      5&      5'      �� 5(   
   $��15,80,15,78q�6   $	��400��6&   ���	#FF2A2E32$��Center=�6L    �� Padding$ 30q�6g    �� CornerRadius$ 10��6t   $	��800��6�   $��2��6�   $	��442��6�    J� Effect 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         
BlurRadius$ 30Q�6#      Color$ DarkSlateGray��63      ShadowDepth$ 0Q�6I   ._�5,      �� -   5         ��Name$ 	MainPanel��5,      .+�5-      �� $��30(�6   $
��Bold"�6*   $��120 0 120 20q�6<   
��������� 6f   $&� Добро пожаловать ��6j   �� 6�   $	�в ��6�   �� 6�   $�MS Logistics��6�   6�   �� 5.      $��20(�6   $
��Bold"�6*   $��280 0 280 20q�6<   
��������� 6f   $"�Продолжить как:��6j   6�   � 5/      $��0 30 0 0q�6   .+�50      �� -   5         ��Name$ ClientButton��50      $��Клиент��63   $��
30,20,0,20q�6D    �� 	ClickMode$ Release=�6s   $
��Left=�6�   $	��300��6�   �� 51      -	   5        $ ManagerButton��51      $��Менеджер��64   $��
0,20,30,20q�6G   $��Right=�6w   $	��300��6�   52      � 53      .+�54      �� -
   5        $ Courier��54      $��Курьер��6.   $��
30,20,0,20q�6?   $
��Left=�6i   $	��300��6�   �� 55      -   5        $ StorageWorkerButton��55      $#��Работник склада��6:   $��
0,20,30,20q�6T   $��Right=�6�   $	��300��6�   56      � 57      .+�58      �� -   5        $ AdminButton��58      $ ��Администратор��62   
�������   MaterialDesignFlatButton#��[  6^   $��220,20q�6�   6�   59      5:      5;      �� 5<   
   -   5        $��
loadborder��5<      $	��189��6#   $	��189��60   $��446,223,0,0q�6<   $	��Top=�6Q   $��2��6i   $
��Left=�6}   ���	#FF00A2FF$��1q�6�   $ 3��6�   $y�Hidden=�6�   ._�5=      �� -   5        $��
LoadingGif��5=   a   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$/ )pack://application:,,,/Images/loading.gif��6   $��Center=�6s   $��Center=�6�   $��2��6�   5>      5?      5@      