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
IsReadOnly& .  6q   5K      '  !MaterialDesignThemes.Wpf.Snackbar  5M      -   5        '  Name$' snack��5M   P   $��Stretch=�62   $��1��6_   5N      5Q        5S      -	   5        $��tabConsulta��5S   !   $ Consulta��64   $��Consulta��6O   ��5T      � 5V      -
   5        ( �Name$( GridLayoutChart��5V      ) � 	Resources) 5W        trackBallTemplate  trackBallTemplate2  pointTemplate��%�  &	       &	 =    &	 �    �� 5X      .R�5Y   "   �� .+�5Z   &   �� $
��Bold"�6\   $��Center=�6n   $��Center=�6�   ��60   �� *DataPoint.CategoryComplete+6�   �� 5[   &   $
��Bold"�6V   $��Center=�6h   ��60   �� *DataPoint.ValueTotal+6h   �� 5\   &   ��60   �� *DataPoint.Value+$$ N2��5]   #   5^      �� 5`      .R�5a   "   �� ��6,   �� *DataPoint.Value+$$ N2��5b      �� 5d      .R�5e   "   �� 
���   �$��4��69   $��4��6C   5f      5g       5i      �� 5j      $��50 �6,   �� 5k      $��* �6,   .+�5n      �� $ 
Horizontal=�6%   $��Center=�6>   $��Center=�6[   .+�5o      (  "System.Windows.Controls.DatePicker  -   5        $��d1��5o   )   $	��100��63   )  #MaterialDesignThemes.Wpf.HintAssist*   Hint$* Data Início��6?    ( $MaterialDesignFloatingHintDatePicker#��[ 6l     5p      -   5        $��d2��5p   )   $	��100��63   $* Data Fim��6?   #��[ 6i   $��10,0,0,0q�6�   �� 5r      -   5        + ��Name$+ cbLocais��5s   !   $��10,0,0,0q�5t   !   $	��200��5u   !   $
 nome��5v   !   , �� SelectedValuePath$, id��5w   !   $* Talhão��5x   !   - �� 
IsEditable- .  & "MaterialDesignFloatingHintComboBox#��[ 5z   !   ��5{   "   �� 5|   &   .R�5}   *   $� 5~   '   5�         RAI.Controls.BtAcao  5�      -   5        .  Name$. 	btFiltrar��5�   (      RAI.Controls.BtAcao/   Click$/ btFiltrar_Click��6M   $��10,0,0,0q�6;   6M   �� 5�      -   5        $��	btGrafico��5�   "   $��10,0,0,0q�63    * &MaterialDesignFloatingActionMiniButton#��[ 5�   "   0 � ToolTip$0 Gráfico��5�   "   .��5�   "   '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��iconGrafico��5�   :   1   Kind$1 ChartBar=�6M   $��24��6]   $��24��6i   5�      � 5�      -   5        $ 
pbConsulta��5�   *   $y�Hidden=�6>   $��10,0,0,0q�6R   #��[ 6d   $ 0Q�6�    . 6�   5�        5�      -   5        $ gridConsulta��5�   %   $��1��6;    5�        5�   "   $ 70Q�6   $
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
observacao+6�   5�      � 5�      -   5        $��
panelChart��5�      $��1��61   $y�	Collapsed=�6>    5�      �� 5�   "   $��25 �60   �� 5�   "   $��* �60   .+�5�      (  "Telerik.Windows.Controls.RadLegend  $��Center=�6a   $	��Top=�6~   $y�Visible=�6�   2   Items2 60   �� *LegendItems+3 �� ElementName$3 chart��4   
ItemsPanel4 5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   5�   '   5�      0  *Telerik.Windows.Controls.RadCartesianChart  5�      -   5        5  Name$5 chart��5�   8   $��1��6G   6   HorizontalAxis6 5�   "   8  2Telerik.Windows.Controls.ChartView.CategoricalAxis  5�   &   -  'Telerik.Windows.Controls.ChartView.Axis7   LabelFitMode$
7 None=�6>   8   LabelRotationAngle$	8 330Q�6R   9   SmartLabelsMode$9 	SmartStep=�6k   6  0Telerik.Windows.Controls.ChartView.CartesianAxis':    IsStepRecalculationOnZoomEnabled: . ;   LabelTemplate; 5�   *   �� 5�   .   .R�5�   2   �� $ Vertical=�6=   .+�5�   6   $  Telerik.Windows.Controls.Label  ��6D   �� 5�   3   5�   /   5�   '   <   VerticalAxis< 5�   "   3  -Telerik.Windows.Controls.ChartView.LinearAxis  5�   &   =   LabelFormat$= N0��69   6  0Telerik.Windows.Controls.ChartView.NumericalAxis>   MinimumA  ;Telerik.Windows.Controls.Converters.StringToDoubleConverter$> 0 6J   $9 	SmartStep=�6V   : . 6r   ?   Grid? 5�   "   ;   5Telerik.Windows.Controls.ChartView.CartesianChartGrid   5�   &   @    MajorLinesVisibility$@ Y=�6A   5!  /Telerik.Windows.Controls.ChartView.RadChartBaseA !  	BehaviorsA 5�   "   ?"  9Telerik.Windows.Controls.ChartView.ChartSelectionBehavior"  5�   &   B "  DataPointSelectionMode$B Single=�6E   @#  :Telerik.Windows.Controls.ChartView.ChartPanAndZoomBehavior#  5�   &   C #  ZoomMode$C 
Horizontal=�6F   D #  DragMode$	D Pan=�6\   ?$  9Telerik.Windows.Controls.ChartView.ChartTrackBallBehavior$  5�   &   5�      5�        5�      -   5        $' snackConsulta��5�   P   $��Stretch=�62   $��1��6g   5�      5�      5�      �� 5�   
   -   5        E ��Name$	E ret��5�      
���   �F J� Opacity$	F 0.5Q�6.   $y�	Collapsed=�6<   $��2��6S   5�      5      