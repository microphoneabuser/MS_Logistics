   M S B A M L   `   `   `  ����F  BNTI_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NTI_projectNTI_project  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      E ADragablz, Version=0.0.3.223, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz 5
      (    "NTI_project.CourierMyOrdersControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:NTI_project     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      0sys&clr-namespace:System;assembly=mscorlib  5	      7dragablz(clr-namespace:Dragablz;assembly=Dragablz  5
      X	 TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5      ���	#FF2D2D30.��5      �   � ColumnDefinitions  5   
   �� 5      �� 5      .+�5   
   � -   5         �Name$ forPhysicalGrid��5      $��2��6(   .+�5      � ���	#FFAEAEAE$��-3q�6*   .+�5      �� $��10q�6   ���	#FF2A2E32 �� Padding$ 30q�6<    �� CornerRadius$ 10��6I    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6+      Color$ DarkSlateGray��6;      ShadowDepth$ 0Q�6Q   ._�5      �� -   5         ��Name$ 	HomePanel��5   !   .+�5      � .+�5      �� -   5        	 ��Name$	 mainText��5   (   $��20(�6:   $
��Bold"�6H   
�������$��Мои заказы��6m   $
��Left=�6   $��Center=�6�   $��10q�6�   �� 5      -   5        $	 comeBackButton��5   (   $9��3< Вернуться к списку заказов��6@   $��13(�6g   
�������$��Center=�6�   $
��0,15q�6c  $��Right=�6q  $	��175��6�  5      �� 5      -   5        $ 	GridPanel��5   %   $	��584��68   $��	0 10 0 10q�6E   $y�Visible=�6X   .+�5      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 
OrdersGrid��5   '   $	��543��6Y      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserResizeColumns .     ClipboardCopyMode$ IncludeHeader=�5!   +      
IsReadOnly .    AutoGenerateColumns .     GridLinesVisibility$	 All=�5"   G      HeadersVisibility$ Column=�6a    J� IsHitTestVisible . ���	#FF303438��5   ;   �� *Items+   Columns 5$   "   0  *System.Windows.Controls.DataGridTextColumn  5%   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6V      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
OrderNum+6t     5&   &   $ 
Адрес��6U   $
 Auto 6d    69   �� *	Address+6s     5'   &   $ Дата��6R   $
 Auto 6`    69   �� *Date+6o     5(   &   $ 
Время��6R   $
 Auto 6a    69   �� *Time+6p     5)   &   $ Вес (кг)��6T   $
 Auto 6f    69   �� *Weight+6u     5*   &   $ Размеры (м)��6R   $
 Auto 6g    69   �� *Size+6v     5+   &   $ Действие��6W   $
 Auto 6i    69   �� *	Operation+6x     5,   &   $ Статус��6T   $
 Auto 6d    69   �� *Status+6s   5.      �� 5/      -   5         ��Name$ checkBox��5/   '       MaterialDesignAccentCheckBox#��[  69   $��Right=�6o   $��10q�6�   $#��Только активные��6�   $��16(�6�   
�������50      51      �� 52      -   5        $ CurrentOrderPanel��52   %   $	��584��6@   $��	0 10 0 10q�6M   $y�	Collapsed=�6`   .+�53      � $��0 0 0 0q�6#   $	��250��64   .+�54   "   �� $
��Left=�6-   $	��465��6H   .+�55   &   � .+�56   *   �� $��Адрес:��64   $��16(�6B   $��SemiBold"�6P   
�������$��5 20 0 5q�6y   $��Center=�6�   6�   #  MaterialDesignThemes.Wpf.Card  57   *   ���	#4C0097FF ! PrimaryHueDarkForegroundBrush#���  6U   $��Center=�6�   $
��Left=�6�   $��
76,20,-1,5q�6�   $	��390��6�   .��58   .   �� -	   5        $	 Address��58   8   $��0��6I   $��8 3 8 3q�6V   $��16(�6g   $��Regular"�6u   $	��...��6�   59   +   5:   '   � 5;   &   .+�5<   *   �� $"��Номер телефона:��64   $��16(�6K   $��SemiBold"�6Y   
�������$��5 5 0 5q�6�   $��Center=�6�   6�     5=   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��	159,5,0,5q�6�   $	��306��6�   .��5>   .   �� -
   5        $	 Phonenumber��5>   8   $��0��6M   $��8 3 8 3q�6Z   $��16(�6k   $��Regular"�6y   $	��...��6�   5?   +   5@   '   � 5A   &   .+�5B   *   �� $��Клиент:��64   $��16(�6C   $��SemiBold"�6Q   
�������$��5 5 0 5q�6z   $��Center=�6�   6�     5C   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��81,5,0,5q�6�   $	��384��6�   .��5D   .   �� -   5        $
	 Name��5D   8   $��0��6F   $��8 3 8 3q�6S   $��16(�6d   $��Regular"�6r   $	��...��6�   5E   +   5F   '   � 5G   &   .+�5H   *   �� $��	Дата:��64   $��16(�6A   $��SemiBold"�6O   
�������$��5 5 0 5q�6x   $��Center=�6�   6�     5I   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��63,5,0,5q�6�   $	��402��6�   .��5J   .   �� -   5        $
	 Date��5J   8   $��0��6F   $��8 3 8 3q�6S   $��16(�6d   $��Regular"�6r   $	��...��6�   5K   +   5L   '   � 5M   &   .+�5N   *   �� $��Время:��64   $��16(�6B   $��SemiBold"�6P   
�������$��5 5 0 5q�6y   $��Center=�6�   6�     5O   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��72,5,0,5q�6�   $	��393��6�   .��5P   .   �� -   5        $
	 Time��5P   8   $��0��6F   $��8 3 8 3q�6S   $��16(�6d   $��Regular"�6r   $	��...��6�   5Q   +   5R   '   5T   #   �� 5V   "   $��	471,0,0,0q�6-   $
��Left=�6@   $	��465��6[   .+�5W   &   � .+�5X   *   �� $#��Вес посылки (кг):��64   $��16(�6M   $��SemiBold"�6[   
�������$��5 20 0 5q�6�   $��Center=�6�   6�     5Y   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��
150,20,0,5q�6�   $	��315��6�   .��5Z   .   �� -   5        $	 Weight��5Z   8   $��0��6H   $��8 3 8 3q�6U   $��16(�6f   $��Regular"�6t   $	��...��6�   5[   +   5\   '   � 5]   &   .+�5^   *   �� $&�� Объём посылки (м3):��64   $��16(�6O   $��SemiBold"�6]   
�������$��5 5 0 5q�6�   $��Center=�6�   6�     5_   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��	181,5,0,5q�6�   $	��284��6�   .��5`   .   �� -   5        $	 Volume��5`   8   $��0��6H   $��8 3 8 3q�6U   $��16(�6f   $��Regular"�6t   $	��...��6�   5a   +   5b   '   � 5c   &   $
��Left=�6+   $	��465��6F   .+�5d   *   �� $��Ширина (м):��64   $��16(�6G   $��SemiBold"�6U   
�������$��5 5 0 5q�6~   $��Center=�6�   6�     5e   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��	114,5,0,5q�6�   $	��351��6�   .��5f   .   �� -   5        $	 Width��5f   8   $��0��6G   $��8 3 8 3q�6T   $��16(�6e   $��Regular"�6s   $	��...��6�   5g   +   5h   '   � 5i   &   $
��Left=�6+   $	��465��6F   .+�5j   *   �� $��Длина (м):��64   $��16(�6F   $��SemiBold"�6T   
�������$��5 5 0 5q�6}   $��Center=�6�   6�     5k   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��98,5,0,5q�6�   $	��367��6�   .��5l   .   �� -   5        $	 Length��5l   8   $��0��6H   $��8 3 8 3q�6U   $��16(�6f   $��Regular"�6t   $	��...��6�   5m   +   5n   '   � 5o   &   $
��Left=�6+   $	��465��6F   .+�5p   *   �� $��Высота (м):��64   $��16(�6G   $��SemiBold"�6U   
�������$��5 5 0 5q�6~   $��Center=�6�   6�     5q   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��	108,5,0,5q�6�   $	��357��6�   .��5r   .   �� -   5        $	 Height��5r   8   $��0��6H   $��8 3 8 3q�6U   $��16(�6f   $��Regular"�6t   $	��...��6�   5s   +   5t   '   5u   #   �� 5v   "   $��	0,203,0,0q�6-   .+�5w   &   � $��	216,5,0,5q�6+   $
��Left=�6>   $	��504��6Y   .+�5x   *   �� $��Вид работы:��64   $��16(�6G   $��SemiBold"�6U   
�������$��5 5 0 5q�6~   $��Center=�6�   6�     5y   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��	112,5,0,5q�6�   $	��353��6�   .��5z   .   �� -   5        $	 	Operation��5z   8   $��0��6K   $��8 3 8 3q�6X   $��16(�6i   $��Regular"�6w   $	��...��6�   5{   +   5|   '   5}   #   5      � 5�      $��0 15 0 0q�6#   .+�5�   "   �� $
��Left=�6-   $	��465��6H   5�   #   �� 5�   "   $��	471,0,0,0q�6-   $
��Left=�6@   $	��465��6[   5�   #   5�      �� 5�      -   5        $
 Done��5�   )   $��	376,0,0,0q�67   $
��Left=�6J   $	��184��6e   $y�	Collapsed=�6q   .+�5�   "   �� $��5q�6)   ���	#FF2A2E32$ 0q�6K   $ 10��6W    5�   &     5�   *   $ 30Q�6;   $ DarkSlateGray��6K   $ 0Q�6a   ._�5�   &   � $
��Left=�6+   $	��932��6F   $��
-392,0,0,0q�6R   .+�5�   *   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Check=�6B   $��40��6O   $��40��6Z   $��Center=�6f   $��400,0,496,0q�6�   ���	#FF008BFF6�   �� 5�   *    $  MaterialDesignHeadline6TextBlock#��[ 64   $��Выполнено��6n   ���	#FF008BFF$��Center=�6�   $��Center=�6�   $��443,7,376,7q�6�   $	��113��6�   6�   5�   '   5�   #   5�      �� 5�      -   5        $ NotDone��5�   )   $
��Left=�6:   $	��936��6U   .+�5�   "   � .+�5�   &   �� -   5         ��Name$ ClientButton��5�   -      MaterialDesignOutlinedButton#��[ 6C   $,��&Связаться с клиентом��6y   $��
38,10,0,10q�6�    �� 	ClickMode$ Release=�6�   $
��Left=�6�   $	��250��6�   �� 5�   &   -   5        $ CancelButton��5�   -   #��[ 6C   $4��.Отказаться от выполнения��6y   $��644,10,0,10q�6�   $ Release=�6�   $
��Left=�6�   $	��259��6�   6�   �� 5�   &   -   5        $ ApplyButton��5�   -   #��[ 6B   $%��Работа выполнена��6x   $��339,10,0,10q�6�   $ Release=�6�   $
��Left=�6�   $	��260��6�   5�   #   5�      5�      5�      5�      5�      5�      �� 5�   
   -   5        $��
loadborder��5�      $��411,263.5,411,263.5q�6#   $��2��6@   ���	#FF00A2FF$��1q�6l   $ 3��6�   $y�Hidden=�6�   ._�5�      �� -   5        $��
LoadingGif��5�   a   "	  WpfAnimatedGif.ImageBehavior 	  AnimatedSource$/ )pack://application:,,,/Images/loading.gif��6   $��Center=�6s   $��Center=�6�   $��2��6�   5�      5�      5�      