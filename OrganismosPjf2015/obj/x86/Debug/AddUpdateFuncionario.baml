   M S B A M L   `   `   `  ����  OrganismosPjf2015,    &OrganismosPjf2015.AddUpdateFuncionario   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
  5      -   5        $	��672��5      $	��352��5      $��AddUpdateFuncionario��5      )  #Telerik.Windows.Controls.WindowBase    
ResizeMode$  NoResize=�5	      (  "Telerik.Windows.Controls.RadWindow   WindowStartupLocation$ CenterScreen=�5
      .��5      � .+�5   
   �� $��23��6   $��	35,24,0,0q�5      $
��Left=�5      $	��Top=�5      $
��Bold"�5      $��Nombramiento:��5      �� 5   
   $��23��6   $��
157,24,0,0q�5      $
��Left=�5      $	��Top=�5      $
��Bold"�5      $��
Apellidos:��5      �� 5   
   $��23��6   $��
402,24,0,0q�5      $
��Left=�5      $	��Top=�5      $
��Bold"�5      $��Nombre:��5      �� 5   
   -   5        $��TxtApellidos��5      $	��222��5      $��23��5       $��
157,53,0,0q�5!      $
��Left=�5"      $	��Top=�5#      ��5$      �� *	Apellidos+ �� Mode$ TwoWay=��� 5&   
   -   5        $��	TxtNombre��5&      $	��238��5'      $��23��5(      $��
402,53,0,0q�5)      $
��Left=�5*      $	��Top=�5+      ��5,      �� *Nombre+$ TwoWay=�*  $Telerik.Windows.Controls.RadComboBox  5.   
   -   5        $��RcbNombramiento��5.      $��90��5/      $��	35,54,0,0q�50      $
��Left=�51      $	��Top=�52         Text 53      �� *Texto+.@�54      .  (Telerik.Windows.Controls.RadComboBoxItem  $��Mgdo.��6&     55      $��Mgda.��6&     56      $
��Juez��6&   57      �� 58   
   $��23��6   $��
35,150,0,0q�59      $
��Left=�5:      $	��Top=�5;      $��13(�5<      $��A partir del:��5=      �� 5>   
   -   5        $��TxtFecha��5>      $	��222��5?      $��23��5@      $��157,148,0,0q�5A      $
��Left=�5B      $	��Top=�5C      ��5D      �� *Texto+( 	 "Telerik.Windows.Controls.RadButton  5E   
   -   5          Name$ RbtnCancelar��5E      $��75��5F      $��23��5G      $��565,277,0,0q�5H      $
��Left=�5I      $	��Top=�5J      $��Cancelar��5L        5M   
   -   5        $��RbtnAceptar��5M      $��75��5N      $��23��5O      $��484,277,0,0q�5P      $
��Left=�5Q      $	��Top=�5R      $��Aceptar��5T      �� 5U   
   $��23��6   $��	39,95,0,0q�5V      $
��Left=�5W      $	��Top=�5X      $��13(�5Y      $��Adscrito al:��5Z      �� 5[   
   -   5         ��Name$ TxtOrganismo��5[      $	��402��5\      $��48��5]      $��
161,95,0,0q�5^      $
��Left=�5_      $	��Top=�5`      $��13(�5a      $��Sin adscripcion��5b      $��WrapWithOverflow=�5c        5d   
   -	   5        $ RbtnEditOrganismo��5d      $��33��5e      $��26��5f      $��
569,92,0,0q�5g      $
��Left=�5h      $	��Top=�5i      .��5k      �� $��Resources/plus.png��6   5l        5n   
   -
   5        $ RbtnEliminar��5n      $��33��5o      $��26��5p      $��
607,91,0,0q�5q      $
��Left=�5r      $	��Top=�5s      .��5u      �� $��Resources/minus.png��6   5v        5w   
   -   5          Name$ CbxEstadoFunc��5w      $	��222��5x      $��157,248,0,0q�5y      $
��Left=�5z      $	��Top=�5{       �� DisplayMemberPath$ Descripcion��5|       �� SelectedValuePath$ 
IdElemento��5~      ��5}      �� 5~      $ 	 Telerik.Windows.Controls.Label  5   
   $��
35,248,0,0q�6   $
��Left=�5�      $	��Top=�5�      $��Estado:��5�      $��13(�5�      �� 5�   
   $��23��6   $��
35,197,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��13(�5�      $��Leyenda:��5�        5�   
   -   5        $ RCbxFunciones��5�      $	��222��5�      $��157,197,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $ Descripcion��5�      $ 
IdElemento��5�      ��5�      �� 5�      5�      5�      