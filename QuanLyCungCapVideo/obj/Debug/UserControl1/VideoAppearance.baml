   M S B A M L   `   `   `  ����M  IQuanLyCungCapVideo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:QuanLyCungCapVideo.UserControl1QuanLyCungCapVideo.UserControl1  5      C&clr-namespace:QuanLyCungCapVideo.ModelQuanLyCungCapVideo.Model  5      5    /QuanLyCungCapVideo.UserControl1.VideoAppearance   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:QuanLyCungCapVideo.UserControl1     5      4m&clr-namespace:QuanLyCungCapVideo.Model     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � 	Resources  5       �� DataType$   QuanLyCungCapVideo.Model.VIDEO
 � Tag �� 
TargetType � LayoutTransform �� Path r�Name r� LoadedBehavior r� Source	 �� CornerRadius
 � RowDefinitions �� Orientation /  +MaterialDesignFloatingActionMiniLightButton'  !MaterialDesignThemes.Wpf.PackIcon�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind % !MaterialDesignSubheadingTextBlock �� Triggers P� Property P� Value N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration N� ExitActions��%�  (��       5      *, +)7   7  �� 6
   "  6   .R�5      � $
��main��6-   $	��300��6   $	��250��6!    69   �� ��5      �� 5      " �6   .�5      -   5        5       5      �� 5      .+�5      �� $
��Fill=�6   ��6'   �� $ 
LinkPoster�6L   r� 5      $ mediaplaytrailer��6   $ Manual=�6Y    69   �� $ Trailer�6Y   r� 5       $ 	mediaplay��6   $ Manual=�6T    62   �� $ 	LinkVideo�6T   �� 5!      $	��0.5q�6   
�������$	 2��6C   $	��3 0q�6T   ._�5"      � 
 5#      �� 5$      �� 5%      �� 5&      .+�5(      � $��2��6   .+�5)      �� $��10q�6)   $ 
Horizontal=�65   $��Right=�6N   $��Bottom=�6j   .+�5*   "   �� $��btnchon��6)   -   5        8��  
������ ���	#FF151415���	#DDFFFFFF$��40��50   )   $��40��51   )    5+   )   �� .��52   &     
������ $��40��6W   $��40��6c   $
 Plus=�6n   53   #   5>      5G      � 5H      $��0��6   .+�5I      �� 8�� 
���������6v   �� $ TenVideo�6�   5J       5K      �� 5L      5O      5Q      5S       5T      P� 5U       �@J�IsMouseOver .  5V      �� 5W      .��5X      �� .��5Y   "   W� $
 main��62   $ LayoutTransform.ScaleX�6O   $	 1.5X�6�   $ 0:0:0.3D�6�   W� 5Z   "   $
 main��62   $ LayoutTransform.ScaleY�6O   $	 1.5X�6�   $ 0:0:0.3D�6�   5[      5\       5^      �� 5_      .��5`      �� .��5a   "   W� $
 main��62   $ LayoutTransform.ScaleX�6O   $ 0:0:0.3D�6�   W� 5b   "   $
 main��62   $ LayoutTransform.ScaleY�6O   $ 0:0:0.3D�6�   5c      5d      5f      5h      5j      .��5k      � .+�5l   
   �� $��Center=�6   .+�5m      �� $
��Auto=�6,   $
��Auto=�6^   ��6   �� ��5o   
   �� 5p      .R�5q      $�  $� Orientation$ 
Horizontal=�6)   5r      ��5t   
   �� 5u       �� 
TargetType" ��6   .R�5v      � $
��main��6    5w      �� 5x      .+�5z      �� $��scrollviewer��6#   ��5{      �� 5|      " ��6.   .R�5}   "   � .+�5~   &   �� 5   #   5�      .��5�      �� $��Center=�6)   5�      � 5�       � ColumnDefinitions 5�      �� 5�      $
��auto �6/   6>   �� 5�      $��* �6/   6;   �� 5�      $
��auto �6/   6>   .+�5�      ��  �� LineLeftCommand#��Z 6'   $��0��5�   1    �� 	ClickMode$ Hover=�5�   2   $
��Auto��6D   $��0q�6R   ��5�   1   ��  �� ElementName$ scrollviewer����5�   ]   Z� ��6s   Z� .��5�        $ KeyboardArrowLeft=�66   $��90��6P   $��90��6\   5�      �� 5�       �� LineRightCommand#��Z 6'   $��2��5�   1   $ Hover=�5�   2   $
��Auto��6D   $��0q�6R   ��5�   1   �� $ scrollviewer����5�   ]   Z� ��6s   Z� .��5�        $ KeyboardArrowRight=�66   $��90��6P   $��90��6\   5�      5�      5�       �� Triggers 5�      5�      5�      5�      5�      5�      