   M S B A M L   `   `   `  ����>  :RAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:RAI.Pages.Cadastros.LocaisRAI.Pages.Cadastros.Locais  5   	   +clr-namespace:RAI.ControlsRAI.Controls  5	   	   1    +RAI.Pages.Cadastros.Locais.PageLocalInclude   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:RAI.Pages.Cadastros.Locais     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   e aTelerik.Windows.Controls, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.PersistenceFramework, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w	 sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k
 gTelerik.Windows.Documents.Core, Version=2023.1.104.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Otelerik1http://schemas.telerik.com/2008/xaml/presentation	    	 
     5   	   9controlsclr-namespace:RAI.Controls	    	 
     5	   	      RAI.Controls.WindowBase    Loaded$  Window_Loaded��5   1    � Title$ Talhão��6	   $	��500��6   $	��400��6%   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   ,  &Telerik.Windows.Controls.RadTabControl  $��0��6    $	��Top=�6-    �� DisplayMemberPath$ Content��6E      DropDownDisplayMode$ 
WhenNeeded=�6a      
ScrollMode$ Viewport=�6�   $��0q�6�   .@�5      )  #Telerik.Windows.Controls.RadTabItem  -   5          Name$ tabDadosBasicos��5   !      DropDownContent$ Dados Básicos��6:   $��Dados Básicos��6Z   ��5      �� 5      .+�5      �� -   5         ��Name$ txtLocal��5   "   $��	10,5,10,0q�64   	 �� 	MaxLength$	 50��6G   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$

 Nome��6V    %  !MaterialDesignFloatingHintTextBox#��[  6|   $��Center=�6�   �� 5      -   5         ��Name$ 
cbFazendas��5      $��	10,5,10,0q�5      $
 nome��5       �� SelectedValuePath$ id��5      $
 Fazenda��5       �� 
IsEditable .  & "MaterialDesignFloatingHintComboBox#��[ 5       ��5!      �� 5"   "   .R�5#   &   $� 5$   #   5&      �� 5(      -   5        $ 
cbCulturas��5)      $��	10,5,10,0q�5*      $
 nome��5+      $ id��5,      $
 Cultura��5-       . #��[ 50      ��51      �� 52   "   .R�53   &   $� 54   #   56      � 58      -   5        $��gridLavoura��58      .+�59      �� .+�5:   "   �� -   5        $ cbVariedades��5;   &   $��	10,5,10,0q�5:   +   $
 nome��5<   &   $ id��5=   &   $
 	Variedade��5>   &    . #��[ 5@   &   ��5A   &   �� 5B   *   .R�5C   .   $� 5D   +   5F   #   �� 5H   "   -   5        $ txtHectares��5H   *   $��	10,5,10,0q�6?   $
 Hectares��6�   #��[  6�   $��Center=�6�   � 5J   "    � ColumnDefinitions 5K   &   �� 5L   *   $��* �6;   �� 5M   *   $��* �6;    5P   &   �� 5Q   *   $��* �68   �� 5R   *   $��* �68   .+�5V   &   �� -   5        $ txtEspacamentoLinha��5V   .   $��10,0,5,0q�6y   $
 Espaçamento entre Linha��6�   #��[  6�   $��Center=�6�   �� 5W   &   -	   5        $ txtEspacamentoPlanta��5W   .   $��5,0,10,0q�6z   $
 Espaçamento entre Planta��6�   #��[  6�   $��Center=�6  $��1��6  �� 5Y   &   -
   5        $ 
txtPlantas��5Y   .   $��10,0,5,0q�6B   $
 Qtde Total de Plantas��6y   #��[  6�   $��Center=�6�   $��1��6  �� 5Z   &   -   5        $ txtPlantasHectare��5Z   .   $��5,0,10,0q�6I    J� Opacity$	 0.8Q�6[    �� 
IsReadOnly . ��.  $
 Plantas por Hectare��6�   #��[  6�   $��Center=�6�   $��1��6  $��1��6(  5[   #   5\      5]      (  "System.Windows.Controls.DatePicker  5_      -   5          Name$ d1��5_   %   $	��100��61   $��	10,5,10,0q�6@   $
 Data do Plantio��6S    ( $MaterialDesignFloatingHintDatePicker#��[ 6�   �� 5a       �� Orientation$ 
Horizontal=�6%   $��Center=�6>   $	��Top=�6[   $��
10,10,10,0q�6s   $��2��6�   $��2��6�   .+�5b      d� -   5         d�Name$ 
optInativo��5b   +    d� 	IsChecked$ FalseY�6?   $��Center=�6Q    $  MaterialDesignSwitchToggleButton#��[ 6l   �� 5c      $��Center=�6(   $��Inativar Talhão��6C   5d      5e      5h        5j      -   5        $ 
tabQuadras��5j   !   $ Quadras��65   $��Quadras��6O   ��5k         RAI.Controls.PonGridLight  5m      -   5          Name$ gridQuadras��5m   ,   $��	10,5,10,0q�6A   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   NewRowPosition$ Bottom=�6T      Columns 5n      1  +Telerik.Windows.Controls.GridViewDataColumn  5o      -	  'Telerik.Windows.Controls.GridViewColumn 	  Width?
  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$	 220
 6i   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$
 Nome��6u    	  ShowFieldFilters .   	  ShowFilterButton .     DataMemberBinding 69   �� *nome+ �� Mode$ TwoWay=� 	  CellEditTemplate 5p   "   �� 5q   &   .R�5r   *   �� $	 50��6U   ��62   �� *nome+$ TwoWay=�6U   5s   '   5u        5w       	  
IsReadOnly .   	  TabStopMode$
  Skip=�6K   $ 20
 6^    .   .  6�   5y      5|      5}         RAI.Controls.BtGravar  5   
   -   5        !  Name$! btGravar��5         RAI.Controls.BtGravar"   Click$" Button_Click��6.   $��1��6C   5�      5�      