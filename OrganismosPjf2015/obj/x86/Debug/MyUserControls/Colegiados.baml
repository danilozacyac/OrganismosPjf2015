   M S B A M L   `   `   `  ����L  HOrganismosPjf2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:OrganismosPjf2015.ConvertersOrganismosPjf2015.Converters  5      1    +OrganismosPjf2015.MyUserControls.Colegiados   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @	converter*clr-namespace:OrganismosPjf2015.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5      -   5        $��UserColegiados��5        � 	Resources  5      3  -OrganismosPjf2015.Converters.MateriaConverter   materiaConverter4  .OrganismosPjf2015.Converters.CircuitoConverter  circuitoConverter5   /OrganismosPjf2015.Converters.OrdinalesConverter  ordinalConverter4  .OrganismosPjf2015.Converters.CiudadesConverter  ciudadConverter6   0OrganismosPjf2015.Converters.NumIntegrantesStyle  integrantes   SinIntegrantes �� 
TargetType3 
 -Telerik.Windows.Controls.GridView.GridViewRow �� Property �� Value   AlgunIntegrante   MasIntegrantes��%�  &	        &	      &	 &     &	 9     &	 L       5   
   6%     5   
   6&     5   
   6'     5   
   6&     5   
    5      �� 5      "  6   .�5      ��  � ��
 � E��63   5       5      �� 5      "  6   .�5      ��  � ��
 �����63   5       5      �� 5      "  6   .�5       ��  � ��
 � ���63   5!      5#      5%      .��5&      � .+�5'   
   / 	 )Telerik.Windows.Controls.RadBusyIndicator  -   5          Name$ BusyIndicator��5'   #      IsIndeterminate . + 	 %Telerik.Windows.Controls.StyleManager	   Theme-	 	 'Telerik.Windows.Controls.ThemeConverter$	 Windows7	 5)   #   .��5*      *
 
 $Telerik.Windows.Controls.RadGridView
  -   5        $��GridColegiados��5*   "   $��Stretch=�5+   "   $��Stretch=�5,   "   ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl
   AutoGenerateColumns
 .     CanUserDeleteRows .     CanUserInsertRows .     
IsReadOnly .    RowStyleSelector# [ 52   "      ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 51   "   ��    Columns 55      1 
 +Telerik.Windows.Controls.GridViewDataColumn  56      6 
 0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ IdOrganismo��57   1   - 
 'Telerik.Windows.Controls.GridViewColumn   	IsVisible .     DataMemberBinding 56   1   �� *IdOrg+58   1     59      $
 Tipo��5:   1    .   59   1   �� *TipoOrganismo+5;   1     5<         Width? 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
 Auto 61   $ 	Organismo��5>   1      IsFilterable .   5=   1   �� *	Organismo+5?   1     5@      $ 50 61   $ Orden Impresión��5B   1    .   5A   1   �� *OrdenImpresion+5C   1     5D      $
 Auto 61   $ Materia��5G   1    .   5E   1   �� *	Materia+ �� 	Converter# [  5H   1     5I      $	 100 61   $ Circuito��5L   1    5J   1   �� *
Circuito+# [ 5L   1     5M      $	 100 61   $ Ordinal��5P   1    5N   1   �� *	Ordinal+# [ 5P   1     5Q      $	 200 61   $ 
Dirección��5S   1    .   5R   1   �� *	Direccion+5T   1     5U      $	 150 61   $ 	Telefonos��5W   1    .   5V   1   �� *	Telefonos+5X   1     5Y      $ 80 61   $ Ciudad��5\   1    5Z   1   �� *Ciudad+# [ 5\   1     5]      $ 50 61   $ Integrantes��5_   1    .   5^   1   �� *ListaFuncionarios.Count+5`   1     5b      $  ��5c   1    .   5b   1   �� *ListaFuncionarios+5d   1   5f      5g      5h      5i      