   M S B A M L   `   `   `  ����F  BNTI_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NTI_projectNTI_project  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      E ADragablz, Version=0.0.3.223, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz 5
      #    NTI_project.AdminStaffControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:NTI_project     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      0sys&clr-namespace:System;assembly=mscorlib  5	      7dragablz(clr-namespace:Dragablz;assembly=Dragablz  5
      X	 TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5      ���	#FF2D2D30.��5      �   � ColumnDefinitions  5   
   �� 5      �� 5      .+�5   
   � -   5         �Name$ forPhysicalGrid��5      $��2��6(   .+�5      � ���	#FFAEAEAE$��-3q�6*   .+�5      �� $��10q�6   ���	#FF2A2E32 �� Padding$ 30q�6<    �� CornerRadius$ 10��6I    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6+      Color$ DarkSlateGray��6;      ShadowDepth$ 0Q�6Q   ._�5      �� -   5         ��Name$ 	HomePanel��5   !   .+�5      � .+�5      �� -   5        	 ��Name$	 mainText��5   (   $��20(�6:   $
��Bold"�6H   
�������$��Сотрудники��6m   $
��Left=�6   $��Center=�6�   $��10q�6�   �� 5      -   5        $	 comeBackButton��5   (   $9��3< Вернуться к списку заказов��6@   $��13(�6g   
�������$��Center=�6�   $��761,15,0,15q�5   �   $
��Left=�6�   $	��175��6�   5      �� 5      -   5        $ 	GridPanel��5   %   $	��584��68   $��	0 10 0 10q�6E   $y�Visible=�6X   .+�5       &   System.Windows.Controls.DataGrid  -   5        
  Name$
 	StaffGrid��5    '   $	��530��6X      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserResizeColumns .     ClipboardCopyMode$ IncludeHeader=�5"   +      
IsReadOnly .    AutoGenerateColumns .     GridLinesVisibility$	 All=�5#   G      HeadersVisibility$ Column=�6a    J� IsHitTestVisible . ���	#FF303438��5    :   �� *Items+   Columns 5%   "   0  *System.Windows.Controls.DataGridTextColumn  5&   &   ,  &System.Windows.Controls.DataGridColumn   Header$
 ИД��6P      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *ID+6k     5'   &   $ Фамилия��6V   $
 Auto 6g    69   �� *
LastName+6v     5(   &   $ Имя��6R   $
 Auto 6_    69   �� *Name+6n     5)   &   $ Должность��6V   $
 Auto 6i    69   �� *
Position+6x     5*   &   $! Номер телефона��6Y   $
 Auto 6q    69   �� *PhoneNumber+6�     5+   &   $' !Электронная почта��6S   $
 Auto 6n    69   �� *Email+6}   5-      �� 5.      -   5         ��Name$ AddStaff��5.   %       MaterialDesignOutlinedButton#��[  67   $+��%Добавить сотрудника��6m   $��200,10q�6�    �� 	ClickMode$ Release=�6�   6�   5/      �� 50      -   5        $ NewStaff��50   %   $y�	Collapsed=�67   .+�51      � $��0 20 0 0q�6#   .+�52   "   �� $��Должность:��6,   $��14(�6>   $��Light"�6L   
�������$��	5,10,0,10q�6r   $��Center=�6�   $
��Left=�6�   $	��931��6�   6�   �� 53   "   -	   5        $��PositionBox��53   +     MaterialDesignComboBox#��[ 6n   $��	104,5,0,5q�6�    �� SelectedIndex$ 0��6�   
�������$
��Left=�6�   $	��208��6�   .@�54   &   �� -
   5        $��managerItem��54   3   .��55   *   �� $��Менеджер��64   6F   56   '   �� 57   &   -   5        $��courierItem��57   3   .��58   *   �� $��Курьер��64   6D   59   '   �� 5:   &   -   5        $��storemanItem��5:   3   .��5;   *   �� $#��Работник склада��64   6M   5<   '   5=   #   5>      �� 5?      -   5         ��Name$ NameBox��5?   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите имя��67    % !MaterialDesignFloatingHintTextBox#��[ 6d   $	��0 5q�6�   
����������	#89FFFFFF|�. 6�   �� 5@      -   5        $ LastNameBox��5@   &   $# Введите фамилию��6;   #��[ 6l   $	��0 5q�6�   
����������	#89FFFFFF|�. 6�   �� 5A      -   5        $ UsernameBox��5A   &   $1 +Введите логин для входа��6;   #��[ 6t   $	��0 3q�6�   
����������	#89FFFFFF|�. 6�   G� 5B      -   5         G�Name$ PasswordBox��5B   *   $! Введите пароль��6?    ) %MaterialDesignFloatingHintPasswordBox#��[ 6o   $	��0 5q�6�   
����������	#89FFFFFF|�. 6�   G� 5C      -   5        $ ConPasswordBox��5C   *   $) #Подтвердите пароль��6B   #��[ 6v   $	��0 5q�6�   
����������	#89FFFFFF|�. 6�   �� 5D      -   5        $ EmailBox��5D   ;   $y�Visible=�6&   $6 0Введите электронную почту��6M   #��[ 6�   $	��0 5q�6�   
����������	#89FFFFFF|�. 6  % 	 Xceed.Wpf.Toolkit.MaskedTextBox  5E      -   5           Name$  PhonenumberBox��5E   1   $7 1Введите ваш номер телефона��6I   #��[ 6�   !   Mask$! 0 (000) 000-0000��6�   $	��0 5q�6�   
�������6  �� 5F      -   5        $ 	AddButton��5F   %   #��[  68   $+��%Добавить сотрудника��6n   $��Center=�6�   $ Release=�6�   $��346,0,350,0q�6�   $	��240��6�   5H      �� 5I      -   5        $ CurrentOrderPanel��5I   %   $	��584��6@   $��	0 10 0 10q�6M   $y�	Collapsed=�6`   .+�5J      � $��0 0 0 0q�6#   .+�5K   "   �� $
��Left=�6-   $	��465��6H   .+�5L   &   � .+�5M   *   �� $��Фамилия:��64   $��16(�6D   $��SemiBold"�6R   
�������$��5 20 0 5q�6{   $��Center=�6�   6�   #	  MaterialDesignThemes.Wpf.Card	  5N   *   ���	#4C0097FF ! PrimaryHueDarkForegroundBrush#���  6U   $��Center=�6�   $
��Left=�6�   $��
94,20,-1,5q�6�   $	��372��6�   .��5O   .   �� -   5        $	 LastName��5O   8   $��0��6J   $��8 3 8 3q�6W   $��16(�6h   $��Regular"�6v   $	��...��6�   5P   +   5Q   '   � 5R   &   .+�5S   *   �� $��Имя:��64   $��16(�6@   $��SemiBold"�6N   
�������$��5 5 0 5q�6w   $��Center=�6�   6�   	  5T   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��57,5,0,5q�6�   $	��408��6�   .��5U   .   �� -   5        $
	 Name��5U   8   $��0��6F   $��8 3 8 3q�6S   $��16(�6d   $��Regular"�6r   $	��...��6�   5V   +   5W   '   � 5X   &   .+�5Y   *   �� $��Должность:��64   $��16(�6F   $��SemiBold"�6T   
�������$��5 5 0 5q�6}   $��Center=�6�   6�   	  5Z   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��	111,5,0,5q�6�   $	��354��6�   .��5[   .   �� -   5        $	 Position��5[   8   $��0��6J   $��8 3 8 3q�6W   $��16(�6h   $��Regular"�6v   $	��...��6�   5\   +   5]   '   5^   #   �� 5`   "   $��	471,0,0,0q�6-   $
��Left=�6@   $	��465��6[   .+�5a   &   � $
��Left=�6+   $	��465��6F   .+�5b   *   �� $"��Номер телефона:��64   $��16(�6K   $��SemiBold"�6Y   
�������$��5 20 0 5q�6�   $��Center=�6�   6�   	  5c   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��
161,20,0,5q�6�   $	��304��6�   .��5d   .   �� -   5        $	 PhoneNumber��5d   8   $��0��6M   $��8 3 8 3q�6Z   $��16(�6k   $��Regular"�6y   $	��...��6�   5e   +   5f   '   � 5g   &   $
��Left=�6+   $	��465��6F   .+�5h   *   �� $(��"Электронная почта:��64   $��16(�6N   $��SemiBold"�6\   
�������$��5 5 0 5q�6�   $��Center=�6�   6�   	  5i   *   ���	#4C0097FF#���  6U   $��Center=�6�   $
��Left=�6�   $��	177,5,0,5q�6�   $	��288��6�   .��5j   .   �� -   5        $	 Email��5j   8   $��0��6G   $��8,3,80,3q�6T   $��16(�6f   $��Regular"�6t   $	��...��6�   5k   +   5l   '   5m   #   5o      �� 5q      $��10q�6)   $	��390��65   .+�5r   "   �� $��Заказы��6,   $��16(�6:   $��SemiBold"�6H   
�������$��
20 10 0 10q�6q   6�     5s   "   -   5        $
 WorkerOrdersGrid��5s   +   $	��349��6h    .   .   .  $	��915��5t   z    .   .  $ IncludeHeader=�5u   +    .  .  $	 All=�5v   G   $ Column=�6a    . ���	#FF303438��5s   E   �� *
OrderItems+ 5x   &     5y   *   $ 
Номер��6Z   $	 305 6i    6=   �� *
OrderNum+6w     5z   *   $ Вид работы��6[   $	 305 6o    6=   �� *	Operation+6}     5{   *   $ Статус заказа��6X   $	 305 6o    6=   �� *Status+6}   5}   #   5~      �� 5      $
��Left=�6)   $	��936��6D   .+�5�   "   � .+�5�   &   �� -   5        $ ConnectButton��5�   -   #��[  6D   $2��,Связаться с сотрудником��6z   $��349,10,0,10q�6�   $ Release=�6�   $
��Left=�6�   $	��274��6�   5�   #   5�      5�      5�      5�      5�      5�      �� 5�   
   -   5        $��
loadborder��5�      $��411,263.5,411,263.5q�6#   $��2��6@   ���	#FF00A2FF$��1q�6l   $ 3��6�   $y�Hidden=�6�   ._�5�      �� -   5        $��
LoadingGif��5�   a   "
  WpfAnimatedGif.ImageBehavior" 
  AnimatedSource$/" )pack://application:,,,/Images/loading.gif��6   $��Center=�6s   $��Center=�6�   $��2��6�   5�      5�      5�      