﻿using Microsoft.EntityFrameworkCore;

namespace CyberSimAware.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Sim> Sims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Ransomware" },
                new Category { CategoryID = 2, Name = "Phishing" },
                new Category { CategoryID = 3, Name = "Social Engineering" }
            );

            modelBuilder.Entity<Sim>().HasData(
                //Ransomware Category Lifecycle Sims
                new Sim
                {
                    SimID = 1, 
                    CategoryID = 1,
                    Code = "1",
                    Name = "Intro to Ransomware",
                    Abstract = "What is Ransomware, and how is it used maliciously?",
                    Info = " - Ransomware is a type of malicious malware that is leveraged for attack where the malware encrypts an organization’s sensitive data, and the attackers then demand some sort of payment to restore access. When the data is encrypted, this locks the organization out of its own system, essentially rendering their data inaccessible. At its core, ransomware is stealing data with the option of leaking or destroying the stolen data unless a condition, usually payment, is met by the victim. These types of attacks also usually halt an organization’s operations and infrastructure as it creates the dilemma of paying the ransom or attempting to restore the data themselves. While ransomware itself is usually delivered by common methods such as social engineering and phishing, the end goal of a ransomware attack is to force an organization to pay a ransom or meet certain conditions. - Understanding ransomware is crucial for everyday users due to the pervasive and disruptive nature of ransomware attacks. With the ever-evolving nature of the digital world, and people’s personal and professional lives being stored and tied into the digital world, it is only going to become more and more necessary to be aware of the dangers of ransomware. As previously stated, ransomware is usually delivered by common attack actors such as phishing or social engineering and therefore makes user awareness all the more valuable. By understanding ransomware, and the risks associated with it, users can become empowered in recognizing suspicious emails, links, attachments, and more. - Ransomware is a direct risk to any information you may store digitally, personally or professionally, and understanding what it is, how to detect it, and how to combat it, will make sure your organization and its users are ultimately in a safer, cybersecure environment."
                },
                new Sim
                {
                    SimID = 2,
                    CategoryID = 1,
                    Code = "2",
                    Name = "Ransomware Preparation",
                    Abstract = "How to Plan for Ransomware",
                    Info = "1 ~ Make sure your software is up to date. - Software providers issue periodic updates that not only keep your programs running well but also include important security patches and upgrades. It’s important to update your security programs—and any other apps and software you use—regularly and promptly. - Many programs will automatically alert you when an update is needed; however, it’s still worthwhile to check on a regular schedule if there are updates available that you may have missed. 2 ~ Layer your Security Measures (a.k.a. “Defense in Depth”) - What does it mean to have a layered approach to security? - Defense in depth involves implementing multiple layers of security measures and controls to protect an organization's information systems and data. The idea is that if one layer of security fails or is breached, there are additional layers in place to provide protection. - This could be a combination of a firewall, antivirus software, anti-malware software, spam filters, and cloud data loss prevention. 3 ~ Conduct Awareness Training. - This relates to insider threat. - Insider Threat is used to describe any action from an employee that compromises the security of an organization’s data and systems. - Train employees on what ransomware is, safe browsing practices, data handling, reporting suspicious activity, Multi-Factor Authentication, strong passwords to go along with MFA, social engineering workshops, regular refreshers every so often. 4 ~ Configure Access Controls. - This relates to Identity and Access Management. - Use the Principle of Least Privilege (PoLP) to actively manage who can access your information. - Essentially, you only give minimal access to files, programs and accounts to those who need it. 5 ~ Back Up Everything! - If your system does get compromised, you can avoid having to pay a ransom by backing everything up regularly—as regularly as every day, if possible. - Store a copy of your system on an external hard drive that’s kept offline and can’t be accessed by anyone but your trusted team. - Maintain a regular backup schedule. 6 ~ Set up strong spam filters to your email and other messaging services. - The United States Small Business Administration (SBA) recommends Enabling strong spam filters to prevent phishing emails (an attempt to obtain sensitive information electronically) from reaching employees and authenticate inbound email using technologies like Sender Policy Framework (SPF), Domain Message Authentication Reporting and Conformance (DMARC), and DomainKeys Identified Mail (DKIM) to prevent email spoofing. 7 ~ Sign up for regular threat reports. - The Anti-Phishing Working Group website provides regular information about phishing attacks. You can also subscribe to CISA product notifications where regular emails will alert you to new activities, threats, and tips produced by the government in response to the threat landscape. 8 ~ Setup Application Whitelisting. - Application Whitelisting is a security measure that allows trusted files, applications, and processes to be run."
                },
                new Sim
                {
                    SimID = 3,
                    CategoryID = 1,
                    Code = "3",
                    Name = "Ransomware Analysis & Detection",
                    Abstract = "Analyzing a security ecosystem at the holistic level to find malicious users",
                    Info = " ~ What is Threat Detection? - Threat Detection is the process of analyzing a security ecosystem at the holistic level to find malicious users, abnormal activity and anything that could compromise a network. Threat detection is built on threat intelligence, which involves tools that are strategic, tactical and operational (CrowdStrike, 2023). - Analysis and Detection services ensure an agency's or division's information security program is fully implemented and maintained (CISA, 2023). ~ Threat Modeling Methods & MITRE Attack Frameworks. - Plan a Cyber Security Strategy: Use ATT&CK to plan your cyber security strategy. Build your defenses to counter the techniques known to be used against your type of organization and equip yourself with security monitoring to detect evidence of ATT&CK techniques in your network. - Run Adversary Emulation Plans: Use ATT&CK for Adversary Emulation Plans to improve Red team performance. Red teams can develop and deploy a consistent and highly organized approach to defining the tactics and techniques of specific threats, then logically assess their environment to see if the defenses work as expected. - Identify Gaps in Defenses: ATT&CK matrices can help Blue teams better understand the components of a potential or ongoing cyber-attack to identify gaps in defenses and implement solutions for those gaps. ATT&CK documents suggested remediations and compensating controls for the techniques to which you are more prone. - Integrate Threat Intelligence: ATT&CK can effectively integrate your threat intelligence into cyber defense operations. Threats can be mapped to specific attacker techniques to understand if gaps exist, determine risk, and develop an implementation plan to address them. ~ Essential Components of (TDR). - Full Attack Vector Visibility: Effective threat detection requires full visibility into all attack vectors, including the network, email, cloud-based applications, mobile apps, and more. Detecting malware is becoming increasingly difficult as malware becomes more sophisticated and evasive. - High Detection Accuracy: Security Operations Center (SOCs) commonly receive many more alerts than they can process, which results in time being wasted investigating false positives while true threats are overlooked. After a potential threat has been identified, security analysts need tools that support incident investigation and remediation. - MITRE Attack Analysis: The MITRE Attack framework provides a wealth of information about the methods by which an attacker can carry out various stages in a cyberattack. Threat detection and response Solutions should provide mappings to MITRE ATT&CK techniques so that security teams can leverage the associated detection and mitigation recommendations provided by the framework. ~ Effective Threat Detection & Response. - Reduce Attack Dwell Time: the longer that an attacker has access to an organization’s systems, the more damage that they can cause. Rapid threat detection reduces dwell time and the complexity of incident remediation. - Decrease cost of Incident Response: An attacker with extended access to an organization’s systems is much more difficult to dislodge and can cause more damage. The sooner that a threat is detected, the lower the cost of remediation. - Optimizing SOC operations: Many SOCs are overwhelmed by low-quality data, resulting in alert fatigue and missed threat detections. An effective TDR solution enables a SOC to focus its efforts on true threats rather than wasting time on false positives."
                },
                //Phising Category 
                new Sim
                {
                    SimID = 4,
                    CategoryID = 2,
                    Code = "550",
                    Name = "#550",
                    Abstract = "",
                    Info = ""
                },
                new Sim
                {
                    SimID = 5,
                    CategoryID = 2,
                    Code = "3439",
                    Name = "#3439",
                    Abstract = "",
                    Info = ""
                },
                new Sim
                {
                    SimID = 6,
                    CategoryID = 2,
                    Code = "2488",
                    Name = "#2488",
                    Abstract = "",
                    Info = ""
                },
                //Social Engineering
                new Sim
                {
                    SimID = 7,
                    CategoryID = 3,
                    Code = "5549",
                    Name = "CloneX #5549",
                    Abstract = "",
                    Info = ""
                },
                new Sim
                {
                    SimID = 8,
                    CategoryID = 3,
                    Code = "1677",
                    Name = "CloneX #1677",
                    Abstract = "",
                    Info = ""
                },
                new Sim
                {
                    SimID = 9,
                    CategoryID = 3,
                    Code = "14433",
                    Name = "CloneX #14433",
                    Abstract = "",
                    Info = ""
                }
            );
        }
    }
}