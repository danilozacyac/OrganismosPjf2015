   M S B A M L   `   `   `  ����  OrganismosPjf2015(    "OrganismosPjf2015.VerInfoOrganismo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5      -   5        $��672.762��5      $��548.714��5      $5��/Organismos del Poder Judicial de la Federación��5      )  #Telerik.Windows.Controls.WindowBase    
ResizeMode$  NoResize=�5	      (  "Telerik.Windows.Controls.RadWindow   WindowStartupLocation$ CenterScreen=�5
      .��5      � .+�5   
   �� -   5        $��TxtOrganismo��5      $	��553��5      $��66��5      $��	52,12,0,0q�5      $
��Left=�5      $	��Top=�5      $��16(�5      $
��Bold"�5       �� TextAlignment$ Center=�5      $��WrapWithOverflow=�5      ��5      �� *	Organismo+5      �� 5   
   -   5        $��TxtDireccion��5      $	��553��5      $��90��5      $��
52,122,0,0q�5      $
��Left=�5      $	��Top=�5       �� AcceptsReturn . $��13(�5      {�.   �� TextWrapping$ WrapWithOverflow=�5!      ��5       �� *	Direccion+5!      �� 5"   
   $��23��6   $��
52,101,0,0q�5#      $
��Left=�5$      $	��Top=�5%      $��14(�5&      $
��Bold"�5'      $��Dirección:��5(      �� 5)   
   $��23��6   $��
52,231,0,0q�5*      $
��Left=�5+      $	��Top=�5,      $��14(�5-      $
��Bold"�5.      $��
Telefonos:��5/      �� 50   
   -   5        $��TxtTelefonos��50      $	��553��51      $��63��52      $��
52,251,0,0q�53      $
��Left=�54      $	��Top=�55       . {�.  $ WrapWithOverflow=�59      ��58      �� *	Telefonos+59      * 
 $Telerik.Windows.Controls.RadGridView  5:   
   -   5        $��GridIntegrantes��5:      $	��553��5;      $	��147��5<      $��
52,335,0,0q�5=      $
��Left=�5>      $	��Top=�5?      ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .  $��14(�5A      {�.    
IsReadOnly .    ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5D      �� *ListaFuncionarios+	   Columns	 5F      1 
 +Telerik.Windows.Controls.GridViewDataColumn  5G      6 
 0Telerik.Windows.Controls.GridViewBoundColumnBase
   Header$
  ��5H   -   - 
 'Telerik.Windows.Controls.GridViewColumn   	IsVisible .     DataMemberBinding 5G   -   �� *IdFuncionario+5I   -     5J         Width?	 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 80	 6-   $
  ��5L   -      IsFilterable .   .  5K   -   �� *Puesto+5N   -     5O      $ *	 6-   $
 	Apellidos��5Q   -    .   5P   -   �� *	Apellidos+5R   -     5S      $ *	 6-   $
 Nombre��5U   -    .   5T   -   �� *Nombre+5V   -     5W      $ 0	 6-   $
  ��5Y   -    .   5X   -   �� *Activo+5Z   -     5[      $ 0	 6-   $
  ��5]   -    .   5\   -   �� *Texto+5^   -   5`      5a      5b      