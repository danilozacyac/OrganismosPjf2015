   M S B A M L   `   `   `  ����  OrganismosPjf20159    3OrganismosPjf2015.MyUserControls.FuncionariosSelect   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5      -   5        .��5      � .+�5   
   * 
 $Telerik.Windows.Controls.RadGridView  -   5        $��GridFuncionarios��5      $��Stretch=�5      $��Stretch=�5      ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl    AutoGenerateColumns  .     CanUserDeleteRows .     CanUserInsertRows .     ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5      ��    Columns 5      5 
 /Telerik.Windows.Controls.GridViewCheckBoxColumn  5      - 
 'Telerik.Windows.Controls.GridViewColumn   Width? 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 30 61      AutoSelectOnEdit .    EditTriggers$ 	CellClick=�5   1   	   	IsVisible	 . 6 
 0Telerik.Windows.Controls.GridViewBoundColumnBase
   DataMemberBinding
 5   1   �� *
IsSelected+ �� Mode$ TwoWay=�5   1   1 
 +Telerik.Windows.Controls.GridViewDataColumn  5         Header$  ��5   -      
IsReadOnly . 	 .  
 5   -   �� *IdFuncionario+5   -     5       $ 90 6-   $ Nombramiento��5"   -    . 	 . 
 5!   -   �� *Puesto+5$   -     5%      $ * 6-   $ 	Apellidos��5'   -      IsFilterable .  . 
 5&   -   �� *	Apellidos+5)   -     5*      $ * 6-   $ Nombre��5,   -    .   . 
 5+   -   �� *Nombre+5.   -     5/      $ 0 6-   $ Activo��51   -    . 	 .  
 50   -   �� *Activo+53   -     54      $ * 6-   $ Texto��56   -    . 	 .  
 55   -   �� *Texto+58   -   5:      5;      5<      