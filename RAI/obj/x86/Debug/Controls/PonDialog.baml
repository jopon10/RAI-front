   M S B A M L   `   `   `  ����>  :RAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RAI.ControlsRAI.Controls  5   	       RAI.Controls.PonDialog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:RAI.Controls     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      RAI.Controls.WindowBase    Loaded$  Window_Loaded��5
   4    � WindowStyle$
 None=�5       � 
ResizeMode$ CanResizeWithGrip=�5	   	    � Title$ 	PonDialog��5
   	   $	��250��6   $	��500��6(   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5           Mode$ 
PrimaryMid=�5   #   $��30��65   $��Stretch=�6A   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��24 �6'   .+�5      �� -   5         ��Name$ 	txtTitulo��5      $��Título��6/   $��20(�6=   $
��Bold"�6K    �� TextAlignment$ Center=�6]   $
��Left=�6t       PrimaryHueMidForegroundBrush#���   6�   $
��10,0q�6�   �� 5      -   5          MaterialDesignIconButton#��[ 5      $��1��6G   |�.  #���   5      	 � ToolTip$	 Fechar��6Q   $��24��5      $��24��6$   $��Right=�62   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Close=�6.   $��18��6;   $��18��6F   5       5!      5"      � 5$   
   $��20,10q�6   $��1��6    5%      �� 5&      $
��Auto �6#   �� 5'      $��* �6#   .+�5*        -   5          Name$
 icon��5*   &   $
 AlertCircle=�64   
����iA�$��60��6^   $��60��6j   $��5,0,20,0q�6u   �� 5,      $��1��6   $��Disabled=�6+   $
��Auto=�6T   .��5-      �� .+�5.      �� -   5        $ txtMensagem��5.       $��Mensagem��65   $��15(�6E   $
��Wrap=�6S   
���   �6g   � 50       51      �� 52      $
��Auto �6/   �� 53      $��* �6/   .+�56      �� -   5        $ txtMensagemTableCol1��56   $   $�� ��6B   $
 Left=�6J   $
��Bold"�6_   $y�	Collapsed=�6q   $��15(�6�   
���   �6�   �� 57      -   5        $ txtMensagemTableCol2��57   $   $�� ��6B   $��1��6J   $y�	Collapsed=�6Z   $��15(�6q   
���   �6   58      59      5;      5<      �� 5>   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��Right=�6;   .+�5?      �� -   5         ��Name$ stackConfirmacao��5?      $ 
Horizontal=�63   $y�	Collapsed=�6L   .+�5@      d� -	   5         d�Name$ optConfirmacao��5@       d� 	IsChecked$
 TrueY�67   $��Center=�6H    $  MaterialDesignSwitchToggleButton#��[ 6c   �� 5A      $��Center=�6   $��	Confirma?��67   $	��5,0q�6H   5B      �� 5D      -
   5         ��Name$
 btOk��5D      $��OK��6#     SecondaryHueMidBrush#���  60   #���  6d    " SecondaryHueMidForegroundBrush#���  6�   $��75��6  $��	2.5,0,5,0q�6#  $y�	Collapsed=�66  {�6�   ��  �� ElementName$ optConfirmacao�� �� Path$ 	IsChecked�6M  �� 5F      -   5        $ btSim��5F      $	��Sim��6$   ���#b0ec04���#b0ec04
���   �$��75��6p   $��	2.5,0,5,0q�6{   $y�	Collapsed=�6�   {�6�   �� $ optConfirmacao��$ 	IsChecked�6�   �� 5G      -   5        $ btNao��5G      $
��Não��6$   
���\\��
���\\��$��75��6a   $��2.5,0,2.5,0q�6l   $y�	Collapsed=�6�   6�   5H      5I      5J      