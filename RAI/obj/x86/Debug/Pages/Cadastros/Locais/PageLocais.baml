   M S B A M L   `   `   `  ����>  :RAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:RAI.Pages.Cadastros.LocaisRAI.Pages.Cadastros.Locais  5      +clr-namespace:RAI.ControlsRAI.Controls  5	      +    %RAI.Pages.Cadastros.Locais.PageLocais   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:RAI.Pages.Cadastros.Locais     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      e aTelerik.Windows.Controls, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.PersistenceFramework, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w	 sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k
 gTelerik.Windows.Documents.Core, Version=2023.1.104.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Otelerik1http://schemas.telerik.com/2008/xaml/presentation	    	 
     5      3myclr-namespace:RAI.Controls	    	 
     5	      -   5        .��5      � .+�5   
   ,  &Telerik.Windows.Controls.RadTabControl  -   5        $	��tab��5       $	��Top=�6+     �� DisplayMemberPath$  Content��5         DropDownDisplayMode$ 
WhenNeeded=�6!      
ScrollMode$ Viewport=�6B   $��0q�6X   .@�5      )  #Telerik.Windows.Controls.RadTabItem  -   5        $��	tabLocais��5   !      DropDownContent$ Talhões��62   $��Talhões��6L      
IsSelected . ��5      � 5       � RowDefinitions 5      �� 5      $��50 �6,   �� 5      $��* �6,   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $
��Left=�6>   $��Center=�6Y   .+�5      �� -   5         ��Name$ btNovo��5   %    $   MaterialDesignRaisedAccentButton#��[  65   $	��150��6o   .��6�   Novo Talhão5      '  !MaterialDesignThemes.Wpf.PopupBox  5         PlacementMode$ BottomAndAlignRightEdges=�66   $��Center=�6_     PrimaryHueMidBrush#���  6|   	   PopupContent.	 5   "   �� $
��Auto��6-   .+�5    &   �� -   5        $ 
btInativos��5    -   $��Talhões Inativos��6A   6\   5!   #   5"      �� 5$      -   5        $ 
btImprimir��5%   !   $��10,0,0,0q�65    * &MaterialDesignFloatingActionMiniButton#��[ 5&   !   
 � ToolTip$
 
Relatório��5'   !   .��5(   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Printer=�6:   $��24��6I   $��24��6U   5)      � 5+      -   5         �Name$ pb��5+   *   $y�Hidden=�66   $��10,0,0,0q�6J    % !MaterialDesignCircularProgressBar#��[ 6]    � Value$ 0Q�6�    � IsIndeterminate . 6�   5,         RAI.Controls.PonGrid  5.      -   5          Name$
 grid��5.   %   $��1��63   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   ShowColumnFooters .    Columns 50      #   RAI.Controls.ButtonColumnEdit  51   "   #   RAI.Controls.ButtonColumnEdit   CustomClick$' !ButtonColumnEditLocal_CustomClick��6\   -	  'Telerik.Windows.Controls.GridViewColumn 	  Header$  ��66    	  MinWidth$ 60Q�6@    	  MaxWidth$ 60Q�6N   6\   #
   RAI.Controls.ButtonColumnShow
  52   "   -	   5         
 Name$ btMapa��52   6   #   RAI.Controls.ButtonColumnShow   CustomClick$ btMapa_CustomClick��6�   $ 60Q�6F   $ 60Q�6T    
  CustomCommand$ OpacityMapaLocal��6b    
  IconKind$ Earth=�6�    � ToolTip$ Mapear��6�   $  ��6�   6�   1  +Telerik.Windows.Controls.GridViewDataColumn  54   "   $	 100Q�6c    	  Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
 auto 6r   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Fazenda��6    	  ShowFieldFilters .   	  ShowFilterButton .  $ 	  EnableDistinctValuesFiltering .   	  DistinctValuesSearchMode$  Contains=�6�   !   DataMemberBinding! 6=   �� *	fazenda+6�     55   "   $	 100Q�6c   $
 auto 6r   $ Cultura��6    .   .   . $  Contains=�6�   ! 6=   �� *	cultura+6�     56   "   $	 100Q�6`   $
 auto 6o   $
 Nome��6|    .   .   . $  Contains=�6�   ! 6=   �� *nome+6�     58   "   $ 70Q�6{   $
 auto 6�   " 	  FooterTextAlignment$" Right=�6�   # 	  HeaderTextAlignment$# Right=�6�   $ 	  TextAlignment$$ Right=�6�   $ Hectares��6�    .   .   . $  
StartsWith=�6M  ! 6=   �� *
hectares+% �� StringFormat$% {0:N2}��& 	  AggregateFunctions& 59   &   &   Telerik.Windows.Data.SumFunction  5:   *   ,  &Telerik.Windows.Data.AggregateFunction'   ResultFormatString$' {0:N2}��6>   5<   #     5>   "   $ 70Q�6z   $
 auto 6�   $" Right=�6�   $# Right=�6�   $$ Right=�6�   $ Plantas��6�    .   .   . $  
StartsWith=�6K  ! 6=   �� *	plantas+$% {0:N0}��& 5?   &     5@   *   $' {0:N0}��6>   5B   #     5D   "   $ 70Q�6�   $	 100 6�   $" Right=�6�   $# Right=�6�   $$ Right=�6�   $ Plantas Por Hectare��6�   ( 	  HeaderTextWrapping$
( Wrap=�6   .   .   . $  
StartsWith=�6x  ! 6=   �� *plantas_hectare+$% {0:N0}��& 5E   &   9   3RAI.Pages.Cadastros.Locais.MyPlantasHectareFunction  5F   *   5H   #     5J   "   $ 70Q�6e   $
 auto 6s   $ 	Variedade��6�    .   .   . $  Contains=�6�   ! 6=   �� *	variedade+6�     5L   "   $ 70Q�6g   $
 auto 6u   $# Right=�6�   $$ Right=�6�   $
( Wrap=�6�   $ Espaçamento��6�    .   .   . $  
StartsWith=�6:  ! 6=   �� *espacamento+6:    5M   "   $ 70Q�6�   $
 auto 6�   $
# Left=�6�   $
$ Left=�6�   $
( Wrap=�6�   $ Plantio��6�    .   .   . $  
StartsWith=�6T  ! 6=   �� *data_plantio+$% {0:dd/MM/yyyy}��6T    5O   "   $ 70Q�6a   $
 auto 6o   $# Right=�6|   $$ Right=�6�   $
( Wrap=�6�   $ Idade
(Anos)��6�   $" Right=�6�    .   .   . $  
StartsWith=�6V  ! 6=   �� *idade+& 5P   &   *  $Telerik.Windows.Data.AverageFunction  5Q   *   $' {0:N0}��6B   5S   #   %   RAI.Controls.ButtonColumnDelete  5U   "   %   RAI.Controls.ButtonColumnDelete)   DeleteClick$$) ButtonColumnDelete_DeleteClick��6q   $  ��68   $ 60Q�6B   $ 60Q�6P   * 	  
IsReadOnly* .  6q   5W      '  !MaterialDesignThemes.Wpf.Snackbar  5Y      -
   5        +  Name$+ snack��5Y   P   $��Stretch=�62   $��1��6_   5Z      5]        5_      -   5        $��tabCulturas��5_   !   $ Culturas��64   $��Culturas��6O   ��5`      � 5b       5c      �� 5d      $��50 �6,   �� 5e      $��* �6,   .+�5h      �� $ 
Horizontal=�6%   $
��Left=�6>   $��Center=�6Y   .+�5m      � -   5        $ 	pbCultura��5m   *   $y�Hidden=�6=   $��10,0,0,0q�6Q   #��[ 6c   $ 0Q�6�    . 6�   5n        5p      -   5        $ gridCultura��5p   %   $��1��6:    5q        5r   "   $	 100Q�6`   $	 350 6o   $
 Nome��6{    .   .   . $  Contains=�6�   ! 6=   �� *nome+6�   5v        5x      -   5        $+ snackCultura��5x   P   $��Stretch=�62   $��1��6f   5y      5|        5~      -   5        $��tabVariedades��5~   !   $ 
Variedades��66   $��
Variedades��6S   ��5      � 5�       5�      �� 5�      $��50 �6,   �� 5�      $��* �6,   .+�5�      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5�      � -   5        $ pbVariedades��5�   *   $y�Hidden=�6@   $��10,0,0,0q�6T   #��[ 6g   $ 0Q�6�    . 6�   5�        5�      -   5        $ gridVariedades��5�   %   $��1��6=    .  5�        5�   "   $	 100Q�6c   $	 150 6r   $ Cultura��6~    .   .   . $  Contains=�6�   ! 6=   �� *	cultura+6�     5�   "   $	 100Q�6`   $	 180 6o   $
 Nome��6{    .   .   . $  Contains=�6�   ! 6=   �� *nome+6�     5�   "   $ Total Hectares��6{   $
( Wrap=�6�   $	 100 6�   $" Right=�6�   $# Right=�6�   $$ Right=�6�    .   .   . $  
StartsWith=�6^  ! 6=   �� *
hectares+$% {0:N2}��& 5�   &     5�   *   $' {0:N2}��6>   5�   #     5�   "   $ Qtde Lavouras��6~   $	 100 6�   $
( Wrap=�6�   $" Right=�6�   $# Right=�6�   $$ Right=�6�    .   .   . $  
StartsWith=�6`  ! 6=   �� *qtde_locais+$% {0:N0}��& 5�   &     5�   *   $' {0:N0}��6>   5�   #   5�        5�      -   5        $+ snackVariedade��5�   P   $��Stretch=�62   $��1��6h   5�      5�      5�      �� 5�   
   -   5        , ��Name$	, ret��5�      
���   �- J� Opacity$	- 0.5Q�6.   $y�	Collapsed=�6<   5�      5�      