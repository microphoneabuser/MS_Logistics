   M S B A M L   `   `   `  ����F  BNTI_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NTI_projectNTI_project  5   	   $    NTI_project.RegistrationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5   	   %localclr-namespace:NTI_project  5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  RegistrationWindow��5
   	   $	��800��6$   $
��1080��61    � WindowStartupLocation$ CenterScreen=�6>    � WindowStyle$
 None=�6c    � 
ResizeMode$ CanMinimize=�6v   .��5      � ���	#FFAEAEAE � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   � -   5         �Name$ Up��5      $��2��6    � RowDefinitions 5      �� 5      $��25 �6    6.   .+�5      � -   5        $��Toolbar��5      $��0��6"   ���	#FF2D2D30$��0q�6F   $	��Top=�6Q   .+�5      � -   5         �Name$ Dragger��5      $��Center=�6+   
������� J� Opacity$	 0.2Q�6U   	 � Points%	 �    z  �  Bp* �  T�*$��180,0q�5      $	��720��6(   5      �� 5      
 �� Orientation$
 
Horizontal=�6   $��Right=�66   .+�5      �� -   5        $��minus_Button��5      ._�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�62   $��16��6?   $��16��6K   $��5q�6V   
������ ���	#FF9191916z   5      �� 5      -   5        $��recover_Button��5      ._�5         $ SquareOutline=�62   $��15��6G   $��15��6S   $��5,4.5,5,4.5q�6^   
������ ���	#FF919191$��Stretch=�6�   5!      �� 5"      -   5        $��close_Button��5"      ._�5#        $ Close=�62   $
��Auto��6?   $��19��6M   $��3,3,5,3q�6X   
������ ���	#FF919191$��Stretch=�6�   5$      5%      5&      5'      �� 5(   
   $��
15,92,15,0q�6   $	��400��6%   ���	#FF2A2E32 �� Padding$ 30q�6K    �� CornerRadius$ 10��6X   $	��800��6j   $��2��6y   $	��638��6�   $	��Top=�6�    J� Effect 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         
BlurRadius$ 30Q�6#      Color$ DarkSlateGray��63      ShadowDepth$ 0Q�6I   ._�5,      �� -   5         ��Name$ 	MainPanel��5,      .+�5-      � $��0 0 0 20q�6   .+�5.      �� $��30(�6    $
��Bold"�6.   
�������$��MS Logistics��6S   $
��Left=�6g   $��Center=�6�   �� 5/      -	   5         ��Name$ comeBackButton��5/       $A��;< Вернуться к стартовой странице��68   $��13(�6c   
�������$��Center=�6�   $��Right=�6�   6}  50      � 51      $��0 0 0 20q�6   .+�52      �� -
   5        $��RegistrationButton��52      $��Регистрация��67   $
��Left=�6M    �� 	ClickMode$ Release=�6�   �� 53      -   5        $��LoginButton��53      $��Вход��60   $��Right=�6?      MaterialDesignFlatButton#��[  6[   ���	#00000000$ Release=�6�   54      �� 55      -   5        $ PanelReg��55      $y�Visible=�6/   .+�56      �� -   5         ��Name$ NameBox��56      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$$ Введите ваше имя��6/    % !MaterialDesignFloatingHintTextBox#��[ 6a   $	��0 5q�6�   
����������	#89FFFFFF|�. 6  �� 57      -   5        $ LastNameBox��57      $, &Введите вашу фамилию��63   #��[ 6i   $	��0 5q�6�   
����������	#89FFFFFF|�. 6  � 58      $��0 15 0 0q�6   .+�59      �� $&�� Выберите вид лица��6      MaterialDesignLabel#��[ 6<   $	��0 5q�6i   
�������$
��Left=�6�   6�   	� 5:      -   5         	�Name$ PhysicalButton��5:   &   $#��Физическое лицо��6>    + 'MaterialDesignUserForegroundRadioButton#��[ 6X   $��	0,5,444,5q�6�   
�������$��Right=�6�   ���	#FF515151 d� 	IsChecked$
 TrueY�6�   6&  	� 5;      -   5        $ LegalButton��5;   &   $%��Юридическое лицо��6;   #��[ 6V   $��	0,5,260,5q�6�   
�������$��Right=�6�   ���	#FF5151516  5<      �� 5=      -   5        $ Organization��5=      $G AВведите название вашей организации��64   #��[ 6x   $	��0 5q�6�   
����������	#89FFFFFF{�.  |�. 6;  �� 5>      -   5        $ UsernameBox��5>      $1 +Введите логин для входа��63   #��[ 6l   $	��0 3q�6�   
����������	#89FFFFFF|�. 6  G� 5?      -   5         G�Name$ PasswordBox��5?   "   $! Введите пароль��67    ) %MaterialDesignFloatingHintPasswordBox#��[ 6g   $	��0 5q�6�   
����������	#89FFFFFF|�. 6  G� 5@      -   5        $ ConPasswordBox��5@   "   $) #Подтвердите пароль��6:   #��[ 6n   $	��0 5q�6�   
����������	#89FFFFFF|�. 6  �� 5A      -   5        $ EmailBox��5A      $6 0Введите электронную почту��60   #��[ 6k   $	��0 5q�6�   
����������	#89FFFFFF|�. 6  5B      �� 5C      -   5        $ 
PanelLogin��5C      $y�	Collapsed=�61   .+�5D      �� -   5        $ UsernameLoginBox��5D      $1 +Введите логин для входа��68   #��[ 6q   $	��0 3q�6�   
����������	#89FFFFFF|�. 6&  G� 5E      -   5        $ PasswordLoginBox��5E   "   $! Введите пароль��6<   #��[ 6l   $	��0 5q�6�   
����������	#89FFFFFF|�. 6%  5F      �� 5G      -   5         ��Name$ RegisterAndLoginButton��5G      $*��$Зарегистрироваться��69   $
��0 20q�6V   $ Release=�6�   5H      5I      �� 5J   
   -   5        $��
loadborder��5J      $	��189��6#   $	��189��60   $��445.5,305.5,445.5,305.5q�6<   $	��Top=�6]   $��2��6u   $
��Left=�6�   ���	#FF00A2FF$��1q�6�   $ 3��6�   $y�Hidden=�6�   ._�5K      �� -   5        $��
LoadingGif��5K   a   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$/ )pack://application:,,,/Images/loading.gif��6   $��Center=�6s   $��Center=�6�   $��2��6�   5L      5M      5N      