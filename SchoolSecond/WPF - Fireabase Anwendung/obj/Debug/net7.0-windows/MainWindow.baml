   M S B A M L   `   `   `  ����T  PWPF - Fireabase Anwendung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WPF___Fireabase_AnwendungWPF___Fireabase_Anwendung  5   	   *    $WPF___Fireabase_Anwendung.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:WPF___Fireabase_Anwendung     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   
�������.��5
      �� .+�5   
   �� -   5         ��Name$ tVorname��5       �� Left$ 28��6$    �� TextWrapping$
 Wrap=�65   $��Vorname��6I   
 �� Top$ 66��6X   $	��197��6h   $
��Left=�6t   $��Center=�6�   �� 5   
   -   5        $ 	tNachname��5      $ 28��6%   $
 Wrap=�66   $��Nachname��6J   $ 89��6Z   $	��197��6j   $
��Left=�6v   $��Center=�6�   �� 5   
   -   5        $ tAlter��5      $ 28��6"   $
 Wrap=�63   $��Alter��6G   $	 112��6T   $	��197��6e   $
��Left=�6q   $��Center=�6�   �� 5   
   -   5        $��Suchen��5      $ 28��6"   $	 135��63   $
��Left=�6D   $��Center=�6_   6z   �� 5   
   -   5        $��Update��5      $ 76��6"   $	 135��63   6D   �� 5   
   -   5        $��Löschen��5      $	 124��6#   $	 135��65   $
��Left=�6F   $��Center=�6a   6|   �� 5   
   -   5        $��	Erstellen��5      $	 176��6%   $	 135��67   6H   �� 5   
   -   5         ��Name$ lbl_Verbindungsstatus��5      $�� ��6/   $ 35��6:   $	 285��6K   $
��Left=�6\   $��Center=�6w   $	��730��6�   �� 5   
   $��Personen Eingabe-Daten��6   $ 28��61   $ 35��6B   $��Center=�6R   $��Center=�6o   $	��197��6�   $��Center=�6�   �� 5   
   -	   5        $ lbl_PersonSuchen��5      $�� ��6*   $	 361��65   $ 17��6G   $
��Left=�6W   $	��Top=�6r   $	��206��6�   $��Center=�6�   &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ PersonsDataGrid��5      $	��123��6,   $	��471��69   $��Center=�6p   $	 241��6�   $	��Top=�6�   $ 61��6�   5      5      