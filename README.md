# AesGcm256WithSalt
A lightweight .NET Core WPF application that provides secure text encryption and decryption using AES‑GCM 256 with support for custom or auto‑generated salt. Designed with clean code, modern cryptographic standards, and a simple UI, offering developers a practical and reliable high‑security encryption tool.

You can pass the salt as a plain text string, but you may also implement a custom class to generate a random salt value. There is no strict limit on the salt length, but it is recommended to keep it within a reasonable range to enhance security.
Important: If the salt is lost, the encrypted data cannot be decrypted under any circumstances, and I am not responsible for that.

The project currently includes a simple demonstration salt, which is only intended to showcase the encryption capabilities. Do not use this built‑in salt in real applications. Instead, either generate your own salt and pass it manually, or pass null so the application automatically generates a random salt between 16 and 128 characters. You do not need to store or access the salt yourself — the algorithm extracts and uses it during decryption.

This implementation follows one of the strongest encryption standards currently available, especially in C#, thanks to the robustness of the underlying algorithm. Microsoft provides powerful low‑level tools such as MemoryStream, BinaryReader, and BinaryWriter, along with full control over array‑based operations. This design makes the encryption workflow easier to understand — almost like building a wall brick by brick — while still maintaining a highly professional and modern security structure.

Because of this, developers should be familiar with the modern GCM (Galois/Counter Mode) encryption standard, which represents the current best practice for authenticated and secure encryption.
This application was created by Ahmad Khaddam 

Deutsch:
Du kannst den Salt‑Wert als normalen Text übergeben oder eine eigene Klasse implementieren, die einen zufälligen Salt generiert. Es gibt keine feste Begrenzung für die Länge des Salt‑Wertes, jedoch empfiehlt es sich, ihn in einem sinnvollen Bereich zu halten, um die Sicherheit zu erhöhen.
Wichtig: Wenn der Salt verloren geht, kann die verschlüsselte Information unter keinen Umständen wieder entschlüsselt werden. Die Verantwortung dafür liegt nicht bei mir.

Im Projekt befindet sich derzeit ein einfacher Demo‑Salt, der ausschließlich dazu dient, die Verschlüsselungsfunktionen zu demonstrieren. Verwende diesen Salt nicht in echten Anwendungen. Generiere stattdessen deinen eigenen Salt oder übergib null, damit die Anwendung automatisch einen zufälligen Salt zwischen 16 und 128 Zeichen erzeugt. Du musst den Salt nicht speichern oder manuell darauf zugreifen — die Verschlüsselungslogik extrahiert ihn beim Entschlüsseln automatisch.

Diese Implementierung basiert auf einem der stärksten verfügbaren Verschlüsselungsstandards, insbesondere in C#, dank der robusten internen Logik des Algorithmus. Microsoft stellt leistungsstarke Low‑Level‑Werkzeuge wie MemoryStream, BinaryReader und BinaryWriter bereit und ermöglicht volle Kontrolle über Array‑Operationen. Dadurch wird der Aufbau des Algorithmus verständlicher — fast so, als würdest du eine Mauer Stein für Stein aufbauen — und gleichzeitig ein professionelles und modernes Sicherheitsniveau gewährleistet.

Aus diesem Grund solltest du mit dem modernen GCM‑Standard (Galois/Counter Mode) vertraut sein, der heute als Best‑Practice für authentifizierte und sichere Verschlüsselung gilt.

Das Programm wurde von Ahmad Khaddam erstellt
