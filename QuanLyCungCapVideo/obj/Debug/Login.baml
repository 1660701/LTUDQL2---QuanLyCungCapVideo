   M S B A M L   `   `   `  ����M  IQuanLyCungCapVideo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:QuanLyCungCapVideoQuanLyCungCapVideo  5   	   Q-clr-namespace:QuanLyCungCapVideo.UserControl1QuanLyCungCapVideo.UserControl1  5   	       QuanLyCungCapVideo.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   ,local clr-namespace:QuanLyCungCapVideo  5   	   6uc-clr-namespace:QuanLyCungCapVideo.UserControl1  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��loginWindow��5   
      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	     LoginVM � DataContext# [ 5   	    � Title$ Login��5   	   $	��692��6   $
��1140��6$   .��5      �  J� RenderTransformOrigin$ 0.478,0.617&�6   ��5   
   �� 5       �� ImageSource$W QC:\Users\Uyen\Desktop\QuanLyCungCapVideo\QuanLyCungCapVideo\background\cap-02.jpg��6   	 � RowDefinitions	 5!   
   �� 5"      $
��auto �6   6,   �� 5#      6   .+�5&   
   � $��0��6   .+�5'      2   ,QuanLyCungCapVideo.UserControl1.ControlBarUC  

 � Tag
 6   �� *Title+ �� ElementName$ loginWindow��6O   5(      � 5)   
   $��1��6   .+�5*        Xceed.Wpf.Toolkit.Wizard     FinishButtonClosesWindow . .@�5+      "  Xceed.Wpf.Toolkit.WizardPage  -   5          Name$ Page1��5+   "      PageType$ Blank=�5,      
�������
������    HeaderBackground �	#FF343434   CanSelectNextPage$
 TrueX�50         CanSelectPreviousPage$
 TrueX�51         NextPage 5/      �� $ Page2��.��52      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6*   $��32q�6[   $	��463��6h   $��150,91,187,0q�6u   ��53      �� 54       �� EndPoint$ 0.5,1&�62    �� 
StartPoint$ 0.5,0&�6C   .��55   "   �  � Color$ Black��6/    � Offset$ 0Q�6=   � 56   "   $ 	#FF575252��6/   $ 1Q�6A   57      .��59      � 	 5:      �� 5;   "   $��60 �60   6>   �� 5<   "   62   �� 5=   "   $��20 �60   6>   �� 5>   "   62   �� 5?   "   62   .+�5A      � $��1��6#   .+�5B   "   �� .+�5C   &   �� $��Center=�6,   $��Center=�6I   
�������$	��600��6w   $��50��6�   $&��  CHÀO MỪNG BẠN ĐẾN VỚI��6�   $��36(�6�   $��Rockwell Bold)�6�   6�   �� 5D   &   $��Center=�6,   $��Center=�6I   
�������$	��600��6w   $��50��6�   $��               TUVFilm!��6�   $��36(�6�   $��Rockwell Bold)�6�   6�   5E   #   5F      � 5G      $��3��6#   .+�5H   "   �� .+�5I   &   �� $��Center=�6-   $��Center=�6J   
�������$	��348��6x   $��51��6�   $$��XEM PHIM KHÔNG GIỚI HẠN, ��6�   $��24(�6�   $��Roboto Light)�6�   $��180,0,181,0q�6�   6�   �� 5J   &   $��Center=�6,   $��Center=�6I   
�������$	��418��6w   $��50��6�   $.��( CHƯƠNG TRÌNH GIẢI TRÍ HẤP DẪN��6�   $��24(�6�   $��Roboto Light)�6�   $��146,0,145,0q�6�   6�   5K   #   5L      � 5M      $��4��6#   .+�5N   "   �� .+�5O   &   �� $��54��6.   $��Center=�6:   $��Center=�6U   $��24(�6r   $��	69,0,49,0q�6�   $	��591��6�   .��6�   ECCoi phim mọi lúc mọi nơi với nhiều ưu đãi hấp dẫn!5Q   '   5R   #   5S      5T      5V      5W        5X      -   5        $ Page2��5X   #   $ Blank=�5Y      
�������
������  �	#FF343434$
 TrueX�5_      $
 TrueX�5`       5]      �� $ Page3��   PreviousPage 5^      �� $ Page1��.��5a      � 	 5b      �� 5c      6.   �� 5d      $	��100 �6,   6;   .+�5f      � $��0��6   .+�5g        $ Depth5=�62   $��32q�5h   "   ���	#FF231F20$��Center=�6F   $��Center=�6c   $	��400��6~   $	��475��6�   $ 0.5,0.5&�6�   $��313,60,322,25q�6�   .��5i   "   � 	 5j   &   �� 5k   *   $��80 �68   6F   �� 5l   *   $��80 �68   6F   �� 5m   *   6:   .+�5o   &   � $��0��6+   .+�5p   *   �� $��40,20,40,10q�62   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên người dùng��5q   2   
�������   
Foreground
 �����.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 ����� �� 
CaretBrush
 ����� �� SelectionBrush
 ��������	#89FFFFFF J� OpacityMask
 ����� % !MaterialDesignFloatingHintTextBox#��[ 5v   2   ��5w   2   �� *
UserName+5x   '   � 5y   &   $��1��6+   .+�5z   *   G� -   5         G�Name$ FloatingPasswordBox��5z   6   
�������  G� 
CaretBrush
  �����! G� SelectionBrush
! ��������	#89FFFFFF$��40,20,40,10q�5   7   $ Mật khẩu��5�   7   
 �����
 �����
 �����.	  (System.Windows.Interactivity.Interaction" 	  Triggers" 5�   .   /
  )System.Windows.Interactivity.EventTrigger
  5�   2   # 
  	EventName$# PasswordChanged��6A   .  (System.Windows.Interactivity.TriggerBase$   Actions.$ 5�   6   6  0System.Windows.Interactivity.InvokeCommandAction  %   Command% 6L   �� *PasswordChangedCommand+&   CommandParameter& 5�   <   �� $ FloatingPasswordBox��5�   3   5�   +   5�   '   � 5�   &   $��2��6+   $��0,25,0,0q�68   	 5�   *   �� 5�   .   6>   �� 5�   .   6>   .+�5�   *   � $��0��6/   $��0,10,0,0q�6<   .+�5�   .   ��   MaterialDesignRaisedButton#���  65   $ Depth4=�5�   1   
����������	#FF231F20' �� 	IsDefault' . $	��160��5�   1   $
��Auto��5�   1   $��121,10,121,3q�5�   f   ��5�   1   �� *LoginCommand+��5�   1   �� $ loginWindow��.��5�   2   ��  # MaterialDesignHeadlineTextBlock#��[ 6<   Đăng Nhập5�   3   5�   /   5�   +   � 5�   *   $��1��6/   .+�5�   .   �� 
�������$��110,25,110,0q�5�   5     MaterialDesignFlatButton#��[ 5�   5   $
��Auto��6h   ��5�   5   �� *	fpCommand+��5�   5   �� $ loginWindow��.��5�   2   ��    MaterialDesignTitleTextBlock#��[ 6<   Quên Mật Khẩu?5�   3   5�   /   5�   +   5�   '   5�   #   5�      5�      � 5�      $��2��6   ( � ColumnDefinitions( 5�      �� 5�   "   65   �� 5�   "   65   .+�5�      � $��0��6#   .+�5�   "   �� 
�������$��Right=�5�   ,    #	 MaterialDesignDisplay1TextBlock#��[	 5�   ,   $��Center=�5�   ,   $��0 0 50 0q�5�   ,   Bạn chưa có tài khoản?5�   #   5�      � 5�      $��1��6#   .+�5�   "   �� $��70��5�   )   $
��Left=�5�   )   $	��180��5�   )   ���	#FF231F20#���  5�   *   $ Depth4=�5�   *   ���	#FFF3F3FF��5�   )   �� *SignUpCommand+��5�   )   �� $ loginWindow��.��5�   &   �� #��[	 60   
Đăng Ký5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      