   M S B A M L   `   `   `  ����L  HOrganismosPjf2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:OrganismosPjf2015.ConvertersOrganismosPjf2015.Converters  5      S.clr-namespace:OrganismosPjf2015.MyUserControls OrganismosPjf2015.MyUserControls  5      *    $OrganismosPjf2015.AddUpdateOrganismo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @	converter*clr-namespace:OrganismosPjf2015.Converters     5      =my.clr-namespace:OrganismosPjf2015.MyUserControls     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5      -   5        $��WinAddOrganismo��5      $	��922��5      $	��764��5	      $4��.Organismo del Poder Judicial de la Federación��5
      (  "Telerik.Windows.Controls.RadWindow    WindowStartupLocation$  CenterScreen=�5      .��5      �  � 	Resources 5   
   2  ,OrganismosPjf2015.Converters.EstadoConverter   estadoConverter��%   &	          5      6(   5      .+�5   
   �� -   5        $��
textBlock1��5      $��23��5      $��	21,23,0,0q�5      $
��Left=�5      $	��Top=�5      $��14(�5      $
��Bold"�5      $��	Organismo��5      �� 5   
   -   5        $��
textBlock2��5      $��23��5      $��
274,23,0,0q�5      $
��Left=�5      $	��Top=�5      $��14(�5      $
��Bold"�5      $��Ordinal��5       �� 5!   
   -   5        $��
textBlock3��5!      $��23��5"      $��
499,23,0,0q�5#      $
��Left=�5$      $	��Top=�5%      $��14(�5&      $
��Bold"�5'      $��Circuito��5(      �� 5)   
   -   5        $��
textBlock4��5)      $��23��5*      $��
771,23,0,0q�5+      $
��Left=�5,      $	��Top=�5-      $��14(�5.      $
��Bold"�5/      $��Orden��50      *  $Telerik.Windows.Controls.RadComboBox  51   
   -   5        $��RcbOrganismo��51      $	��184��52      $��	21,52,0,0q�53      $
��Left=�54      $	��Top=�55       �� DisplayMemberPath$ Descripcion��56      {�.  �� SelectedValuePath$ 
IdElemento��59      ��58      �� 59        5:   
   -   5        $��
RcbOrdinal��5:      $	��176��5;      $��
274,52,0,0q�5<      $
��Left=�5=      $	��Top=�5>      $ Descripcion��5?      $ 
IdElemento��5A      ��5@      �� 5A        5B   
   -   5        $��RcbCircuito��5B      $	��179��5C      $��
499,52,0,0q�5D      $
��Left=�5E      $	��Top=�5F      $ Descripcion��5G      $ 
IdElemento��5I      ��5H      �� 5I      �� 5J   
   -	   5        $��TxtOrdenImpresion��5J      $	��100��5K      $��23��5L      $��
770,51,0,0q�5M      $
��Left=�5N      $	��Top=�5O      ��5P      �� *OrdenImpresion+ �� Mode$ TwoWay=��� 5R   
   -
   5        $��	groupBox1��5R      $	��657��5S      $	��126��5T      $��
21,104,0,0q�5U      $
��Left=�5V      $	��Top=�5W      $��Materia��5X      {�.  .��5Z      � .+�5[      �� -   5        $��ChkPenal��5[      $��22��5\      $��	19,18,0,0q�5]      $
��Left=�5^      $	��Top=�5_      $�� Penal��5`      $��14(�5a      �� 5b      -   5        $��ChkAdministrativa��5b      $��22��5c      $��	19,62,0,0q�5d      $
��Left=�5e      $	��Top=�5f      $�� Administrativa��5g      $��14(�5h      �� 5i      -   5        $��ChkCivil��5i      $��22��5j      $��
193,18,0,0q�5k      $
��Left=�5l      $	��Top=�5m      $�� Civil��5n      $��14(�5o      �� 5p      -   5        $��
ChkLaboral��5p      $��22��5q      $��
0,62,386,0q�5r      $��Right=�5s      $	��Top=�5t      $�� Laboral��5u      $��14(�5v      �� 5w      -   5        $��	ChkAmparo��5w      $��22��5x      $��
373,18,0,0q�5y      $
��Left=�5z      $	��Top=�5{      $,��& de Amparo y Juicios Civiles Federales��5|      $��14(�5}      �� 5~      -   5        $��	checkBox6��5~      $��22��5      $��
373,62,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $$�� de Procesos Penales Federales��5�      $��14(�5�      5�      5�      �� 5�   
   -   5        $��
textBlock5��5�      $��23��5�      $��698,112,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��14(�5�      $
��Bold"�5�      $��Ciudad��5�        5�   
   -   5        $��	RcbCiudad��5�      $	��192��5�      $��698,141,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $ 	CiudadStr��5�      $ IdCiudad��5�      ��5�      �� 5�      �� 5�   
   -   5        $��
textBlock6��5�      $��23��5�      $��698,169,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��14(�5�      $
��Bold"�5�      $��Estado��5�      �� 5�   
   -   5        $��	TxtEstado��5�      $	��192��5�      $��23��5�      $��698,198,0,0q�5�      $
��Left=�5�      $	��Top=�5�      {�.  ��5�      �� *Ciudad+ �� 	Converter# [  �� 5�   
   -   5        $��LblDescripcion��5�      $	��147��5�      $��28��5�      $��723,227,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Construir descripción��5�       � Cursor$
 Hand��5�      $��14(�5�      $��Italic$�5�      ���	#FF0BAAFD5�      �� 5�   
   -   5        $��
textBlock7��5�      $��23��5�      $��
21,246,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��14(�5�      $
��Bold"�5�      $��Descripción��5�      �� 5�   
   -   5        $��TxtDescTribunal��5�      $	��651��5�      $��44��5�      $��
21,275,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��14(�5�      ��5�      �� *	Organismo+$ TwoWay=��� 5�   
   -   5        $��
textBlock8��5�      $��23��5�      $��
21,340,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��14(�5�      $
��Bold"�5�      $��
Dirección��5�      �� 5�   
   -   5        $��TxtDireccion��5�      $	��429��5�      $	��103��5�      $��
21,369,0,0q�5�      $
��Left=�5�      $	��Top=�5�       �� AcceptsReturn .  �� TextWrapping$ WrapWithOverflow=�5�      ��5�      �� *	Direccion+$ TwoWay=�5�      �� 5�   
   -   5        $��
textBlock9��5�      $��23��5�      $��475,340,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��14(�5�      $
��Bold"�5�      $��
Teléfonos��5�      �� 5�   
   -   5        $��TxtTelefono��5�      $	��267��5�      $	��103��5�      $��475,369,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��14(�5�      $ WrapWithOverflow=�5�      ��5�      �� *	Telefonos+$ TwoWay=�5�      �� 5�   
   -   5        $��textBlock10��5�      $��23��5�      $��
21,478,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��14(�5�      $
��Bold"�5�      $��Integrantes��5�      * 
 $Telerik.Windows.Controls.RadGridView  5�   
   -   5        $��GridIntegrantes��5�      $	��429��5�      $	��147��5�      $��
21,507,0,0q�5�      $
��Left=�5�      $	��Top=�5�      ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5�      �� *ListaFuncionarios+   Columns 5�      1 
 +Telerik.Windows.Controls.GridViewDataColumn  5�      - 
 'Telerik.Windows.Controls.GridViewColumn   Width?	 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 80	 6-   6
 
 0Telerik.Windows.Controls.GridViewBoundColumnBase 
  Header$  ��5   -      IsFilterable .     	IsVisible .  
  DataMemberBinding 5�   -   �� *Puesto+5  -     5     $ *	 6-   $ 	Apellidos��5  -    .   5  -   �� *	Apellidos+5  -     5     $ *	 6-   $ Nombre��5	  -    .   5  -   �� *Nombre+5
  -   5     ( 	 "Telerik.Windows.Controls.RadButton  5  
   -   5        $��RbtnCancelar��5     $��70��5     $��35��5     $��800,670,0,0q�5     $
��Left=�5     $	��Top=�5     $��Cancelar��5      �� IsCancel . 5       5  
   -   5        $��RbtnAceptar��5     $��70��5     $��35��5     $��723,670,0,0q�5     $
��Left=�5     $	��Top=�5     $��Aceptar��5      �� 	IsDefault .  5       5  
   -    5        $��RbtnAgregaFuncionario��5     $	��135��5      $��35��5!     $��171,670,0,0q�5"     $
��Left=�5#     $	��Top=�5$     $��Agregar Funcionario��5&       5'  
   -!   5        $��RbtnEliminar��5'     $	��135��5(     $��35��5)     $��
21,670,0,0q�5*     $
��Left=�5+     $	��Top=�5,     $��Eliminar Funcionario��5.     � 50  
   -"   5        $��PopupFuncionario��50     $	��600��51     $	��350��52     {�. ��.  $��Center=�55     .��56     �� $��Seleccionar funcionarios��6   .��57     �  � RowDefinitions 58     �� 59     $��* �6(   �� 5:     $��35 �6(   .+�5<     � -#   5         �Name$ SelectControl��5<     $��0��5=     $��Stretch=�5>     $��Stretch=�5?       5A     -$   5        $��RbtnPopAceptar��5A  (   $��1��5B  (   $��75��5C  (   $��25��5D  (   $��0,5,87,5q�5E  (   $��Right=�5F  (   $��Aceptar��5H  (     5I     -%   5        $��RbtnPopCancelar��5I  (   $��1��5J  (   $��75��5K  (   $��25��5L  (   $��0,5,6,5q�5M  (   $��Right=�5N  (   $��Cancelar��5P  (   5Q     5S     5T     �� 5U  
   -&   5         ��Name$ textBlock10_Copy��5U     $��23��5V     $��475,478,0,0q�5W     $
��Left=�5X     $	��Top=�5Y     $��14(�5Z     $
��Bold"�5[     $��
Presidente��5\     �� 5]  
   -'   5         ��Name$ TxtPresidente��5]     $	��267��5^     $��23��5_     $��475,513,0,0q�5`     $
��Left=�5a     $	��Top=�5b     {�.  $
 Wrap=�5e     5g     5h     