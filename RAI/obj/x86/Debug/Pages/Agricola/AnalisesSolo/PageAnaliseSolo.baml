   M S B A M L   `   `   `  ����>  :RAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:RAI.Pages.Agricola.AnalisesSoloRAI.Pages.Agricola.AnalisesSolo  5      +clr-namespace:RAI.ControlsRAI.Controls  5	      5    /RAI.Pages.Agricola.AnalisesSolo.PageAnaliseSolo   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:RAI.Pages.Agricola.AnalisesSolo     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      e aTelerik.Windows.Controls, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.PersistenceFramework, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w	 sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k
 gTelerik.Windows.Documents.Core, Version=2023.1.104.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Otelerik1http://schemas.telerik.com/2008/xaml/presentation	    	 
     5      3myclr-namespace:RAI.Controls	    	 
     5	      -   5        .��5      � .+�5   
   ,  &Telerik.Windows.Controls.RadTabControl  -   5           Name$	  tab��5        �� DisplayMemberPath$ Content��6-      DropDownDisplayMode$ 
WhenNeeded=�6I      
ScrollMode$ Viewport=�6j   $��0q�6�   .@�5      )  #Telerik.Windows.Controls.RadTabItem  -   5        $��tabAnalises��5   !      DropDownContent$ 	Análises��64   $��	Análises��6O      
IsSelected . ��5      � 5       � RowDefinitions 5      �� 5      $��50 �6,   �� 5      $��* �6,   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $
��Left=�6>   $��Center=�6Y   .+�5      �� -   5         ��Name$ btNovo��5   %    $   MaterialDesignRaisedAccentButton#��[  65   $	��150��6o   .��6�   Nova Análise5      ,  &Telerik.Windows.Controls.RadDatePicker  5      -   5        	  Name$	 dt��5   4   $	��202��6@   $��10,0,0,0q�6L   0  *Telerik.Windows.Controls.RadDateTimePicker
   DateSelectionMode$
 Month=�6�      DateTimeWatermarkContent$ Competência��6�    =� ErrorTemplate 6^   Z� 6�   � 5      -   5         �Name$ pb��5   *   $y�Hidden=�66   $��10,0,0,0q�6J    % !MaterialDesignCircularProgressBar#��[ 6]    � Value$ 0Q�6�    � IsIndeterminate . 6�   5          RAI.Controls.PonGrid  5"      -   5          Name$
 grid��5"   %   $��1��63   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   Columns 5#      #   RAI.Controls.ButtonColumnEdit  5$   "   #   RAI.Controls.ButtonColumnEdit   CustomClick$" ButtonColumnEdit_CustomClick��6\   -	  'Telerik.Windows.Controls.GridViewColumn 	  Header$  ��66    	  MinWidth$ 60Q�6@    	  MaxWidth$ 60Q�6N   6\   #
   RAI.Controls.ButtonColumnShow
  5%   "   #   RAI.Controls.ButtonColumnShow   CustomClick$ btCalagem_CustomClick��6\   $  ��66   $ 60Q�6@   $ 60Q�6N    � ToolTip$ Calagem��6�    
  IconKind$ AlphabetCCircle=�6�    
  CustomCommand$ VisibleCalagem��6�   
  5&   "   $ btCalagem_CustomClick��6\   $  ��66   $ 60Q�6@   $ 60Q�6N   $ Gessagem��6�   $ AlphabetGCircle=�6�   $ VisibleGessagem��6�   1  +Telerik.Windows.Controls.GridViewDataColumn  5(   "   $ 70Q�6    	  Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
 Auto 6�    	  HeaderTextAlignment$
 Left=�6�    	  TextAlignment$
 Left=�6�    	  HeaderTextWrapping$
 Wrap=�6�   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$
 Data��6�    	  ShowFieldFilters .    	  ShowFilterButton  .  $! 	  EnableDistinctValuesFiltering! . " 	  DistinctValuesSearchMode$" 
StartsWith=�6I  #   DataMemberBinding# 6=   �� *data+$ �� StringFormat$$ {0:dd/MM/yyyy}��6I    5)   "   $	 200 6d   $ Laboratório��6p    .    .  ! . $" Contains=�6�   # 6=   �� *
parceiro+6�     5*   "   $	 200 6c   $ Fazenda��6o    .    .  ! . $" Contains=�6�   # 6=   �� *	fazenda+6�     5+   "   $	 200 6a   $ Talhão��6m    .    .  ! . $" Contains=�6�   # 6=   �� *local+6�     5,   "   $	 200 6b   $ Quadra��6n    .    .  ! . $" Contains=�6�   # 6=   �� *quadra+6�     5-   "   $
 Auto 6h   $ Profundidade��6u    .    .  ! . $" Contains=�6�   # 6=   �� *profundidade+6�     5.   "   $ Right=�6u   $ Right=�6�   $ 80 6�   $ pH��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *ph+$$ {0:N2}��6    5/   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $
 M.O.��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *mo+$$ {0:N2}��6    50   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ P��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *p+$$ {0:N2}��6    51   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ K��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *k+$$ {0:N2}��6    52   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Ca��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *ca+$$ {0:N2}��6    53   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Mg��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *mg+$$ {0:N2}��6    54   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Na��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *na+$$ {0:N2}��6    55   "   $ Right=�6w   $ Right=�6�   $ 75 6�   $
 H+Al��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *h_al+$$ {0:N2}��6    56   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Al��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *al+$$ {0:N2}��6    57   "   $ Right=�6v   $ Right=�6�   $ 75 6�   $	 CTC��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *ctc+$$ {0:N2}��6    58   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $
 S.B.��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *sb+$$ {0:N2}��6    59   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ V%��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *v+$$ {0:N2}��6    5:   "   $ Right=�6y   $ Right=�6�   $
 Auto 6�   $ 
%Ca na CTC��6�    .    .  ! . $" 
StartsWith=�6#  # 6=   �� *ca_ctc+$$ {0:N2}��6#    5;   "   $ Right=�6y   $ Right=�6�   $
 Auto 6�   $ 
%Mg na CTC��6�    .    .  ! . $" 
StartsWith=�6#  # 6=   �� *mg_ctc+$$ {0:N2}��6#    5<   "   $ Right=�6x   $ Right=�6�   $
 Auto 6�   $ 	%K na CTC��6�    .    .  ! . $" 
StartsWith=�6!  # 6=   �� *k_ctc+$$ {0:N2}��6!    5=   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ m%��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *m+$$ {0:N2}��6    5>   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ S��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *s+$$ {0:N2}��6    5?   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ B��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *b+$$ {0:N2}��6    5@   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Cu��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *cu+$$ {0:N2}��6    5A   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Fe��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *fe+$$ {0:N2}��6    5B   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Mn��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *mn+$$ {0:N2}��6    5C   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Zn��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *zn+$$ {0:N2}��6    5D   "   $ Right=�6y   $ Right=�6�   $ 75 6�   $ Argila��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *argila+$$ {0:N2}��6    5E   "   $ Right=�6x   $ Right=�6�   $ 75 6�   $ Silte��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *silte+$$ {0:N2}��6    5F   "   $ Right=�6x   $ Right=�6�   $ 75 6�   $ Areia��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *areia+$$ {0:N2}��6    5G   "   ! . $" Contains=�6�   $	 300 6�   $ Observação��6�    .    .  # 6=   �� *
observacao+6�   %   RAI.Controls.ButtonColumnDelete  5I   "   %   RAI.Controls.ButtonColumnDelete%   DeleteClick$$% ButtonColumnDelete_DeleteClick��6q   $  ��68   $ 60Q�6B   $ 60Q�6P   & 	  
IsReadOnly& .  6q   5K      '  !MaterialDesignThemes.Wpf.Snackbar  5M      -   5        '  Name$' snack��5M   P   $��Stretch=�62   $��1��6_   5N      5Q        5S      -	   5        $��tabConsulta��5S   !   $ Consulta��64   $��Consulta��6O   ��5T      � 5V       5W      �� 5X      $��50 �6,   �� 5Y      $��* �6,   .+�5\      �� $ 
Horizontal=�6%   $��Center=�6>   $��Center=�6[   .+�5]      (  "System.Windows.Controls.DatePicker  -
   5        $��d1��5]   )   $	��100��63   )  #MaterialDesignThemes.Wpf.HintAssist(   Hint$( Data Início��6?    ( $MaterialDesignFloatingHintDatePicker#��[ 6l     5^      -   5        $��d2��5^   )   $	��100��63   $( Data Fim��6?   #��[ 6i   $��10,0,0,0q�6�   �� 5`      -   5        ) ��Name$) cbLocais��5a   !   $��10,0,0,0q�5b   !   $	��200��5c   !   $
 nome��5d   !   * �� SelectedValuePath$* id��5e   !   $( Talhão��5f   !   + �� 
IsEditable+ .  & "MaterialDesignFloatingHintComboBox#��[ 5h   !   ��5i   "   �� 5j   &   .R�5k   *   $� 5l   '   5n         RAI.Controls.BtAcao  5p      -   5        ,  Name$, 	btFiltrar��5p   (      RAI.Controls.BtAcao-   Click$- btFiltrar_Click��6M   $��10,0,0,0q�6;   6M   �� 5r      -   5        $��	btGrafico��5s   "   $��10,0,0,0q�63    * &MaterialDesignFloatingActionMiniButton#��[ 5t   "   . � ToolTip$. Gráfico��5u   "   .��5v   "   '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��iconGrafico��5v   :   /   Kind$/ ChartBar=�6M   $��24��6]   $��24��6i   5w      � 5�      -   5        $ 
pbConsulta��5�   *   $y�Hidden=�6>   $��10,0,0,0q�6R   #��[ 6d   $ 0Q�6�    . 6�   5�        5�      -   5        $ gridConsulta��5�   %   $��1��6;    5�        5�   "   $ 70Q�6   $
 Auto 6�   $
 Left=�6�   $
 Left=�6�   $
 Wrap=�6�   $
 Data��6�    .    .  ! . $" 
StartsWith=�6I  # 6=   �� *data+$$ {0:dd/MM/yyyy}��6I    5�   "   $	 200 6d   $ Laboratório��6p    .    .  ! . $" Contains=�6�   # 6=   �� *
parceiro+6�     5�   "   $	 200 6c   $ Fazenda��6o    .    .  ! . $" Contains=�6�   # 6=   �� *	fazenda+6�     5�   "   $	 200 6a   $ Talhão��6m    .    .  ! . $" Contains=�6�   # 6=   �� *local+6�     5�   "   $	 200 6b   $ Quadra��6n    .    .  ! . $" Contains=�6�   # 6=   �� *quadra+6�     5�   "   $
 Auto 6h   $ Profundidade��6u    .    .  ! . $" Contains=�6�   # 6=   �� *profundidade+6�     5�   "   $ Right=�6u   $ Right=�6�   $ 80 6�   $ pH��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *ph+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $
 M.O.��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *mo+$$ {0:N2}��6    5�   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ P��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *p+$$ {0:N2}��6    5�   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ K��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *k+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Ca��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *ca+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Mg��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *mg+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Na��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *na+$$ {0:N2}��6    5�   "   $ Right=�6w   $ Right=�6�   $ 75 6�   $
 H+Al��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *h_al+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Al��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *al+$$ {0:N2}��6    5�   "   $ Right=�6v   $ Right=�6�   $ 75 6�   $	 CTC��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *ctc+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $
 S.B.��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *sb+$$ {0:N2}��6    5�   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ V%��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *v+$$ {0:N2}��6    5�   "   $ Right=�6y   $ Right=�6�   $
 Auto 6�   $ 
%Ca na CTC��6�    .    .  ! . $" 
StartsWith=�6#  # 6=   �� *ca_ctc+$$ {0:N2}��6#    5�   "   $ Right=�6y   $ Right=�6�   $
 Auto 6�   $ 
%Mg na CTC��6�    .    .  ! . $" 
StartsWith=�6#  # 6=   �� *mg_ctc+$$ {0:N2}��6#    5�   "   $ Right=�6x   $ Right=�6�   $
 Auto 6�   $ 	%K na CTC��6�    .    .  ! . $" 
StartsWith=�6!  # 6=   �� *k_ctc+$$ {0:N2}��6!    5�   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ m%��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *m+$$ {0:N2}��6    5�   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ S��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *s+$$ {0:N2}��6    5�   "   $ Right=�6t   $ Right=�6�   $ 75 6�   $ B��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *b+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Cu��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *cu+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Fe��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *fe+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Mn��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *mn+$$ {0:N2}��6    5�   "   $ Right=�6u   $ Right=�6�   $ 75 6�   $ Zn��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *zn+$$ {0:N2}��6    5�   "   $ Right=�6y   $ Right=�6�   $ 75 6�   $ Argila��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *argila+$$ {0:N2}��6    5�   "   $ Right=�6x   $ Right=�6�   $ 75 6�   $ Silte��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *silte+$$ {0:N2}��6    5�   "   $ Right=�6x   $ Right=�6�   $ 75 6�   $ Areia��6�    .    .  ! . $" 
StartsWith=�6  # 6=   �� *areia+$$ {0:N2}��6    5�   "   ! . $" Contains=�6�   $	 300 6�   $ Observação��6�    .    .  # 6=   �� *
observacao+6�   5�      � 5�      -   5        $��
panelChart��5�      $��1��61   $y�	Collapsed=�6>    5�      �� 5�   "   $��25 �60   �� 5�   "   $��* �60   .+�5�      (  "Telerik.Windows.Controls.RadLegend  $��Center=�6a   $	��Top=�6~   $y�	Collapsed=�6�   0   Items0 60   �� *LegendItems+1 �� ElementName$1 chart��2   
ItemsPanel2 5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   5�   '   5�      0  *Telerik.Windows.Controls.RadCartesianChart  5�      -   5        3  Name$3 chart��5�   8   5  /Telerik.Windows.Controls.ChartView.RadChartBase4   Palette>  8Telerik.Windows.Controls.ChartView.ChartPaletteConverter$4 Windows8 6G   $��1��6Z   5   HorizontalAxis5 5�   "   8  2Telerik.Windows.Controls.ChartView.CategoricalAxis  5�   &   -  'Telerik.Windows.Controls.ChartView.Axis6   LabelFitMode$
6 None=�6>   7   LabelRotationAngle$	7 330Q�6R   8   SmartLabelsMode$8 	SmartStep=�6k   6  0Telerik.Windows.Controls.ChartView.CartesianAxis'9    IsStepRecalculationOnZoomEnabled9 . :   LabelTemplate: 5�   *   �� 5�   .   .R�5�   2   �� $ Vertical=�6=   .+�5�   6   $  Telerik.Windows.Controls.Label  ��6D   �� 5�   3   5�   /   5�   '   ;   VerticalAxis; 5�   "   3  -Telerik.Windows.Controls.ChartView.LinearAxis  5�   &   <   LabelFormat$< N0��69   6   0Telerik.Windows.Controls.ChartView.NumericalAxis=    MinimumA!  ;Telerik.Windows.Controls.Converters.StringToDoubleConverter$= 0! 6J   $8 	SmartStep=�6V   9 . 6r   >   Grid> 5�   "   ;"  5Telerik.Windows.Controls.ChartView.CartesianChartGrid"  5�   &   ? "  MajorLinesVisibility$? Y=�6A   @   	Behaviors@ 5�   "   ?#  9Telerik.Windows.Controls.ChartView.ChartSelectionBehavior#  5�   &   A #  DataPointSelectionMode$A Single=�6E   @$  :Telerik.Windows.Controls.ChartView.ChartPanAndZoomBehavior$  5�   &   B $  ZoomMode$B 
Horizontal=�6F   C $  DragMode$	C Pan=�6\   5�      5�        5�      -   5        $' snackConsulta��5�   P   $��Stretch=�62   $��1��6g   5�      5�      5�      �� 5�   
   -   5        D ��Name$	D ret��5�      
���   �E J� Opacity$	E 0.5Q�6.   $y�	Collapsed=�6<   $��2��6S   5�      5�      