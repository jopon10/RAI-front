   M S B A M L   `   `   `  ����>  :RAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:RAI.Pages	RAI.Pages  5   	       RAI.Pages.PageMenu   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:RAI.Pages     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   e aTelerik.Windows.Controls, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.PersistenceFramework, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w	 sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k
 gTelerik.Windows.Documents.Core, Version=2023.1.104.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Otelerik1http://schemas.telerik.com/2008/xaml/presentation	    	 
     5   	     � WindowStyle$
  None=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ CanResizeWithGrip=�6A    � WindowState$ 	Maximized=�6`    � Title$  ��5   	   $	��600��6   $	��900��6    � 	Resources 5      5  /Telerik.Windows.Controls.StringToGlyphConverter   StringToGlyphConverter  IconTemplate'  !Telerik.Windows.Controls.RadGlyph   Glyph��%]   &	        &	        5   
   6)   �� 5   
   .R�5         6   �� 5      5      .��5      �  5   
     NavigationViewItemStyle �� 
TargetType4  .Telerik.Windows.Controls.RadNavigationViewItem  RadNavigationViewItemStyle �� BasedOn	 �� Property
 �� Value   PrimaryHueMidForegroundBrush'  !MaterialDesignThemes.Wpf.PackIcon   Kind J� Opacity ��Name'  !Telerik.Windows.Controls.RadBadge   Badge  Name   	BadgeType   Position �� Triggers �� Value �� Binding �� 
TargetName  NullToVisibilityConverter �� 	Converter ! NavigationViewContentTemplate��%�  &	       7  7  &	     �� 5      "  64   8   .�5      �� 	 � ��$
 15(�6-   �� 5      	 � ��#
 �  6/   �� 5      	 � ��
 6/   �� *
FontWeight+�� 5      	 �@ ExpandedIconTemplate
 5      �� 5      .R�5        $ 	ChevronUp=�66   $	 0.6Q�6G   $��24��6U   $��24��6`   $��Center=�6l   $��Center=�6�   #���  6�   5      5      �� 5       	 �@ CollapsedIconTemplate
 5!      �� 5"      .R�5#        $ ChevronDown=�66   $	 0.6Q�6I   $��24��6W   $��24��6b   $��Center=�6n   $��Center=�6�   #���  6�   5$      5&      �� 5'      	 � {�
 6.   �� *	IsEnabled+�� 5(      	 � ��
 6,   �� �� 5)      	 � ��
 5*      �� 5+      .R�5,      �� $ 	TextBlock��6(   ��6;   �� *Title+ 5-   &     5.   *   $ Badge��6;   
���  ��$
��Bold"�51   )   $ ContentOnly=�52   )   $ 1.5,0.5&�53   )   ��5/   )   �� *NotificationsCount+53   )   55       56      �� 57   "   $ 0��6U    6.   �� *NotificationsCount+.a�58   &   �� $ 	TextBlock��6-   
 6f   Z� 	 �@ Badge59   #   5;      5=      �� 5>      	 �@ ItemsSource
 60   �� *
SubItems+�� 5?      	 �@ ItemContainerStyle#
 �  67   �� 5@      	 �@ Icon
 6)   �� *Icon+�� 5A      	 �@ IconTemplate
 5B      �� 5C      .R�5D        $��Center=�6G   $��Center=�6b   #���  6    66   �� 6   5E      5G      �� 5H      	 �@ IconVisibility
 63   �� *Icon+8  5I      �� 5K      .R�5L      � $��8q�6   .+�5M      >� -   5        ��5M   "   �� *page+6;   5N      5O      5P       � RowDefinitions 5R   
   �� 5S      $��38 �6   �� 5T      $��* �6   .+�5W   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5           Mode$ 
PrimaryMid=�5W   #   $��38��65   $��Stretch=�6A   .��5X      �  � ColumnDefinitions 5Y      �� 5Z      $��* �6'   �� 5[      $��* �6'   �� 5\      $��* �6'   .+�5_      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   .+�5b      �� $	��RAI��6    $��20(�6+   $
��Bold"�69   $��Center=�6K   5c      �� 5e      $ 
Horizontal=�6   $��1��66   $��Center=�6F   $��Center=�6a   .+�5f      �� -   5        $ 
lbFantasia��5f       $��Center=�64   $
��Bold"�6O   $
��10,0q�6a   �� 5g      -   5        $ lbUser��5g       $��Center=�60   $
��Bold"�6K   $
��10,0q�6]   �� 5h      -   5        $ lbVersao��5h       $��Center=�62   $
��Bold"�6M   $
��10,0q�6_   5i      '  !MaterialDesignThemes.Wpf.PopupBox  5k         PlacementMode$ BottomAndAlignRightEdges=�6*   $��2��6S   $��Right=�6c      PopupContent. 5l      �� $	��150��6!   .+�5m      �� -   5        $��	Minimizar��5m   !   65   �� 5n      -   5        $
��Sair��5n   !   60   5o      5p      5q      5r      0  *Telerik.Windows.Controls.RadNavigationView  5t   
   -   5          Name$ NavigationView��5t   $   $��1��6<      AutoChangeDisplayMode .     SubItemsIndentation$ 50Q�5u   B       DisplayMode$  Expanded=�5v   $   !!   AllowMultipleExpandedItems! .  9	  3Telerik.Windows.Controls.Animation.AnimationManager" 	  IsAnimationEnabled" . #���  5x   $     PrimaryHueMidBrush#   PaneBackground## �  5y   $   $   PaneHeaderBackground#$ �  5z   $   %   PaneHeaderForeground#% �  5{   $   ��5t   I   �� *Items+ 5}      +
  %Telerik.Windows.Controls.StyleManager-  'Telerik.Windows.Controls.ThemeConverter��%�   '��       �� 5~      " ��6   .�5      �� 	 �@
 Theme$
 Fluent 6C   �� 5�      	 �@J�Opacity$

 0.75Q�60   5�      5�      &   Content& 5�      3  -Telerik.Windows.Controls.RadTransitionControl  5�      -	   5        '  Name$' pageTransitionControl��5�   /   #��[ 5�   /   (   Duration$( 0:0:0.6h�5�   N   ��5�   /   �� *SelectedItem+) �� ElementName$) NavigationView��*   
Transition* 5�      ?  9Telerik.Windows.Controls.TransitionEffects.FadeTransition  5�      5�      5�      5�      5�      