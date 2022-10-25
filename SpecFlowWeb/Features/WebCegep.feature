Feature: WebCegep

Scenario: Ouvrir la page d'accueil du cégep
	Given L'adresse du site web est https://cegepsth.qc.ca
	When J'ouvre la page
	Then le titre devrait contenir Rive-Sud
	And le titre devrait contenir Cégep


Scenario: accéder à la page
	Given L'adresse du site web est https://cegepsth.qc.ca
	When J'ouvre la page
	And  Je clique sur le lien contenant le texte <texte>
	And Je passe à l'onglet <fenetre>
	Then le titre devrait contenir <titre>

	Examples: site
		| texte                       | titre     | fenetre |
		| Consulter la page transport | Transport | 0       |
		| Voir les offres disponibles | Emplois   | 1       |
