   M S B A M L   `   `   `  ����>  :RAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:RAI.Pages.Agricola.AnalisesSoloRAI.Pages.Agricola.AnalisesSolo  5   	   +clr-namespace:RAI.ControlsRAI.Controls  5	   	   <    6RAI.Pages.Agricola.AnalisesSolo.PageAnaliseSoloInclude   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:RAI.Pages.Agricola.AnalisesSolo     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   e aTelerik.Windows.Controls, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.PersistenceFramework, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w	 sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k
 gTelerik.Windows.Documents.Core, Version=2023.1.104.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Otelerik1http://schemas.telerik.com/2008/xaml/presentation	    	 
     5   	   9controlsclr-namespace:RAI.Controls	    	 
     5	   	      RAI.Controls.WindowBase    Loaded$  WindowBase_Loaded��5   :    � Title$ Análise de Solo��6	   $	��750��6!   $	��450��6.   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   �� $
��10,0q�6   .+�5         RAI.Controls.PonCombo  -   5          Name$ cbParceiros��5      $��0,5,0,0q�5       �� DisplayMemberPath$
 nome��5       �� SelectedValuePath$ id��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Laboratório��5       �� 
IsEditable .  &  "MaterialDesignFloatingHintComboBox#��[  5      ��5      �� 5      .R�5      $� 5      5!        5#      -   5        $ cbLocais��5$         RAI.Controls.PonCombo   SelectionChanged$ cbLocais_SelectionChanged��5*      $��0,5,0,0q�5%      $
 nome��5&      $ id��5'      $ Talhão��5(       . #��[  5+      ��5,      �� 5-      .R�5.      $� 5/      51        53      -   5        $ 	cbQuadras��54      $��0,5,0,0q�55      $
 nome��56      $ id��57      $ Quadra��58       . #��[  5:      ��5;      �� 5<      .R�5=      $� 5>      5@      � 5B      	 � ColumnDefinitions	 5C      �� 5D      $��* �6'   �� 5E      $��* �6'   .+�5H      (  "System.Windows.Controls.DatePicker  -   5        
  Name$
 d1��5H      $	��100��6)   $��0,5,5,0q�68   $
 Data��6I    ( $MaterialDesignFloatingHintDatePicker#��[ 6o   �� 5J      -   5         ��Name$ cbProdundidade��5K      $��5,5,0,0q�5L      $ Profundidade��5M       . $��1��5O      #��[  5P      .@�5R      �� $��0-10 cm��6#   �� 5S      $��0-20 cm��6#    �� 
IsSelected . 65   �� 5T      $��20-40 cm��6#   �� 5U      $��40-60 cm��6#   ��5W      �� 5X      .R�5Y      $� 5Z      5\      5]      �� 5_      -   5         ��Name$ txtObs��5_      $��0,5,0,0q�6&    �� 	MaxLength$	 500��67   $ Observação��6G    % !MaterialDesignFloatingHintTextBox#��[ 6s   5`         RAI.Controls.PonGridLight  5b   
   -   5          Name$
 grid��5b       $��10,20,10,10q�6.   $��1��6C   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   Columns 5c      1  +Telerik.Windows.Controls.GridViewDataColumn  5d      -	  'Telerik.Windows.Controls.GridViewColumn 	  HeaderTextAlignment$
 Left=�6W    	  TextAlignment$
 Left=�6r    	  Width?
  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$	 100
 6�   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ 	Nutriente��6�    	  ShowFieldFilters .   	  ShowFilterButton .   	  
IsReadOnly .    DataMemberBinding 6-   �� *nomeProduto+6�   5  /Telerik.Windows.Controls.GridViewComboBoxColumn  5f      -   5          Name$ 
cbExtrator��5f   1   $ Extrator��6E   $	 100
 6~    	  MinWidth$	 100Q�6�    	  
UniqueName$ Extrator��6�      SelectedValueMemberPath$ sigla��6�      DisplayMemberPath$ sigla��6�      IsComboBoxEditable .  6W   �� *
extrator+   ItemsSourceBinding 6  �� *
extratores+    EditorStyle  5g      �� 5h      ! �� 
TargetType*  $Telerik.Windows.Controls.RadComboBox"!  6    .�5i      �� " �� Property" �@ OpenDropDownOnFocus# �� Value# . 6D   �� 5j      (" �@  CanKeyboardNavigationSelectItems$
# TrueX�6Q   �� 5k      "" �@ CanAutocompleteSelectItems$
# TrueX�6K   �� 5l      " �@ TextSearchMode$# Contains=�6?   �� 5m      " �@ IsFilteringEnabled# . 6C   �� 5n      " � ��# 5o   "   �� 5p   &   .R�5q   *   �� 5r   '   5t      5u      5w        5y      -	   5        $ 	cbUnidade��5y   1   $ Unidade��6D   $	 100
 6{   $	 100Q�6�   $ Unidade��6�   $ sigla��6�   $ sigla��6�    .  6U   �� *	unidade+ 6�   �� *unidades_analise_solo+  5z      �� 5{      "!  6    .�5|      �� " �@ OpenDropDownOnFocus# . 6D   �� 5}      (" �@  CanKeyboardNavigationSelectItems$
# TrueX�6Q   �� 5~      "" �@ CanAutocompleteSelectItems$
# TrueX�6K   �� 5      " �@ TextSearchMode$# Contains=�6?   �� 5�      " �@ IsFilteringEnabled# . 6C   �� 5�      " � ��# 5�   "   �� 5�   &   .R�5�   *   �� 5�   '   5�      5�      5�        5�      $ Right=�6m   $ Right=�6�   $	 100
 6�   $ 
Quantidade��6�    .   .   6-   �� *
quantidade+$ �� StringFormat$$ {0:N2}��6�   5�         RAI.Controls.BtGravar  5�   
   -
   5        %  Name$% btGravar��5�         RAI.Controls.BtGravar&   Click$& Button_Click��6.   $��2��6C   5�      5�      