   M S B A M L   `   `   `  ����L  HPokemonLikeCsharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PokemonLikeCsharp.ViewModelPokemonLikeCsharp.ViewModel  5   	   "    PokemonLikeCsharp.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :MVVM)clr-namespace:PokemonLikeCsharp.ViewModel     5   	     � Title$  	Connexion��5   	   ���#F0F4F8 � WindowState$ 	Maximized=�5   	    � WindowStyle$
 None=�5   	    � DataContext 5
      0   *PokemonLikeCsharp.ViewModel.LoginViewModel  5   
   -   5        	ViewModel��5       � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value  
InputStyle��%�  &	        &	 �    �� 5   
   " ��6$   .�5      ��  � �� �#2196F36+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� �#1976D26,   �� 5       � ��$ 1q�60   �� 5       � ��$ Stretch=�64   �� 5       � ��$ 45��6'   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6#   .�5      ��  � ��$ 5q�6'   �� 5        � ��$ 10q�6(   �� 5!       � �� �#B0BEC56,   �� 5"       � ��$ 1q�60   �� 5#       � ��$ 14(�6)   5$      5%      .��5'      � $��30q�6    � RowDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $��* �6   .+�5.   
   �� $��	Connexion��6   $��28(�6%   $
��Bold"�63   ���#333$��Center=�5/      $��10q�61   �� 52   
   $��1��6   $��Center=�6"   $��Center=�6=   $	��350��6Z   .+�53      �� $��Nom d'utilisateur��6   $��5q�61   $��14(�6<   �� 54      #��[ 6U   ��6   �� *
Username+	 �� UpdateSourceTrigger$	 PropertyChanged=�6U   �� 56      $��Mot de passe��6   $��5q�6,   $��14(�67   G� 57      -   5        
 G�Name$
 passwordBox��57      #��[ 6/   58      �� 5:      -   5        $��Se connecter��5:      #��[  6,   5;      �� 5<      -   5        $��Créer un compte��5<      #��[  6/   5=      �� 5>      -   5        $��Quitter��5>      #��[  6'   ���#F443365?      5@      5A      5B      