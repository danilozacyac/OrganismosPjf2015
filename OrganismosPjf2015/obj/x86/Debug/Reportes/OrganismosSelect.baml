   M S B A M L   `   `   `  ����  OrganismosPjf20151    +OrganismosPjf2015.Reportes.OrganismosSelect   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5      -   5        $	��700��5      $	��450��5      $'��!Seleccionar organismos a imprimir��5      (  "Telerik.Windows.Controls.RadWindow    WindowStartupLocation$  CenterScreen=�5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   * 
 $Telerik.Windows.Controls.RadGridView  -   5          Name$ RgridOrganismo��5      $��1��5      $��Stretch=�5      $��Stretch=�5      ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     CanUserDeleteRows .     CanUserInsertRows .     ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5      ��    Columns 5      5 
 /Telerik.Windows.Controls.GridViewCheckBoxColumn  5      	   AutoSelectOnEdit	 . - 
 'Telerik.Windows.Controls.GridViewColumn
   EditTriggers$
 	CellClick=�5   1   6 
 0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$   ��5    1      	IsVisible .    DataMemberBinding 5   1   �� *
IsSelected+ �� Mode$ TwoWay=�5!   1   1 
 +Telerik.Windows.Controls.GridViewDataColumn  5"      $ IdOrganismo��5#   -    .   5"   -   �� *IdOrg+5$   -     5%      $
 Tipo��5&   -    .   5%   -   �� *TipoOrganismo+5'   -     5(         Width?	 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ *	 6-   $ 	Organismo��5*   -      IsFilterable .   5)   -   �� *	Organismo+5+   -     5,      $
 Auto	 6-   $ Materia��5.   -    .   .   5-   -   �� *	Materia+50   -     51      $	 100	 6-   $ Circuito��53   -    .   52   -   �� *
Circuito+54   -     55      $	 100	 6-   $ Ordinal��57   -    .   56   -   �� *	Ordinal+58   -     59      $	 200	 6-   $ 
Dirección��5;   -    .   .   5:   -   �� *	Direccion+5=   -     5>      $	 150	 6-   $ 	Telefonos��5@   -    .   .   5?   -   �� *	Telefonos+5B   -     5C      $ 80	 6-   $ Ciudad��5E   -    .   5D   -   �� *Ciudad+5F   -     5G      $ 50	 6-   $ Integrantes��5I   -    .   .   5H   -   �� *ListaFuncionarios.Count+5K   -     5L      $ 50	 6-   $ Orden Impresión��5N   -    .   .   5M   -   �� *OrdenImpresion+5P   -     5Q      $  ��5R   -    .   5Q   -   �� *ListaFuncionarios+5S   -   5U      (
 	 "Telerik.Windows.Controls.RadButton
  5V   
   -   5         
 Name$ RbtnColegiados��5V      $	��138��5W      $��
149,10,0,0q�5X      $
��Left=�5Y      $	��Top=�5Z      $��T. Colegiados��5\      
  5]   
   -   5        $ RbtnUnitarios��5]      $	��134��5^      $��
292,10,0,0q�5_      $
��Left=�5`      $	��Top=�5a      $��T. Unitarios��5c      
  5d   
   -   5        $ RbtnJuzgados��5d      $	��131��5e      $��	431,0,0,8q�5f      $
��Left=�5g      $��Bottom=�5h      $��Juzgados��5j      
  5k   
   -   5        $ RbtnCancelar��5k      $��2��5l      $��84��5m      $��	581,8,0,0q�5n      $
��Left=�5o      $	��Top=�5p      $��Cancelar��5r      
  5s   
   -   5        $ RbtnAceptar��5s      $��2��5t      $��84��5u      $��	478,8,0,0q�5v      $
��Left=�5w      $	��Top=�5x      $��Aceptar��5z      
  5{   
   -   5        $ 
RBtnPlenos��5{      $	��134��5|      $��	10,10,0,0q�5}      $
��Left=�5~      $	��Top=�5      $��Plenos de Circuito��5�      5�      5�      