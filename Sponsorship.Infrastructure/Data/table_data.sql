--
-- PostgreSQL database dump
--

\restrict zUjmsAnLrASBvTVD8iphZy2daiTMYHMy0dSc3yWllxi3NRaLJJgXzxKFc1t7wzy

-- Dumped from database version 18.0
-- Dumped by pg_dump version 18.0

-- Started on 2026-05-24 19:39:06

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 5046 (class 0 OID 16542)
-- Dependencies: 225
-- Data for Name: app_users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.app_users (user_id, email, first_name, last_name, password_hash, pass_set_on, created_at, updated_at, is_active, role_id) FROM stdin;
90c7f968-fa6b-47de-b86a-da75c5d253f7	fin@test.com	Fin	user	AQAAAAIAAYagAAAAEFsemwynAVavmcJ7xubAPZK1DAby3De8lMZQ/8SqIUWIaxhXoavyyqzjsu7GePRo8Q==	2026-05-21 21:52:52.268923	2026-05-21 19:43:44.21791	\N	t	2
fd10f39e-c0ea-450e-b39b-be7a1946ff8a	sys@test.com	Sys	user	AQAAAAIAAYagAAAAEKCTLOUmuLC1t2k3VHvj3bgfmzWIHI72AohcFO4B4mDQV5H4GTt3hVcBUsZwsnZu6A==	2026-05-21 22:28:11.93112	2026-05-21 19:34:46.212206	\N	t	1
76410011-0969-4c0f-b353-25ff8cd25341	man@test.com	Manager	user	AQAAAAIAAYagAAAAEFpQ215QdWWGmIizeBmQLpYbVJTheHaubsEF8dewvGFpYWxM+8PRGZOMOujatabdrg==	2026-05-21 22:27:53.041063	2026-05-21 19:48:32.263643	\N	t	3
3ccbfb80-52b6-4af0-9816-6be514ab750c	user@test.com	Josim	Ahmed	AQAAAAIAAYagAAAAEIHkt3pm1F4auTLSJkr1mnl8b8TZAYAdL2MgWpUjw8o3uZ2jDnwRwuopd50P2qOIxw==	2026-05-21 22:27:35.736879	2026-05-21 19:48:37.573845	\N	t	4
3ccbfb80-52b6-4af0-9816-6be514ab7501	user1@test.com	Requestor	user	AQAAAAIAAYagAAAAEIHkt3pm1F4auTLSJkr1mnl8b8TZAYAdL2MgWpUjw8o3uZ2jDnwRwuopd50P2qOIxw==	2026-05-21 22:27:35.736879	2026-05-21 19:48:37.573845	\N	t	4
\.


--
-- TOC entry 5044 (class 0 OID 16507)
-- Dependencies: 223
-- Data for Name: departments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.departments (dep_code, dep_name, description, is_active) FROM stdin;
HRM	Human Resource Management	Handles recruitment, employee relations, and HR policies	t
FIN	Finance	Manages budgeting, accounting, and financial reporting	t
ITC	IT & Communications	Responsible for software systems, infrastructure, and technical support	t
MKT	Marketing	Handles branding, promotions, and marketing campaigns	t
OPS	Operations	Oversees day-to-day business operations and process management	t
SAL	Sales	Manages client acquisition, sales strategy, and revenue growth	t
LEG	Legal & Compliance	Ensures legal compliance, contracts, and regulatory affairs	t
RND	Research & Development	Focuses on innovation, product development, and research activities	t
\.


--
-- TOC entry 5041 (class 0 OID 16461)
-- Dependencies: 220
-- Data for Name: sponsorship_requests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sponsorship_requests (sponsorship_id, request_title, requestor_name, department, sponsorship_type, event_organisation_name, event_date, requested_amount, purpose, expected_business_benefit, remarks, status_code, created_at, updated_at, created_by, updated_by) FROM stdin;
019e55e9-61e5-7778-b530-0b56184df212	TKKKK	kama 9977	HRM	COR	sdf	2026-05-23	100.00	sdf	sadf	sdf	PMA	2026-05-23 23:36:58.85338+06	2026-05-24 13:12:59.530371+06	3ccbfb80-52b6-4af0-9816-6be514ab750c	3ccbfb80-52b6-4af0-9816-6be514ab750c
019e58d5-03b3-7acf-b3b2-4ef634ba3f6e	Jony	Jony99	FIN	EVT	asdf	2026-05-24	0.00	asfd	asfd	asfd	DRA	2026-05-24 13:13:35.660335+06	2026-05-24 13:13:42.675666+06	3ccbfb80-52b6-4af0-9816-6be514ab750c	3ccbfb80-52b6-4af0-9816-6be514ab750c
019e498e-e91d-78e5-80f4-825c563059a3	Mrss	Small Fund	ITC	VIP	Test Event	2026-05-21	450000.00	test 	we will kno it later	NO	APR	2026-05-21 14:02:43.100887+06	2026-05-23 15:50:12.449906+06	3ccbfb80-52b6-4af0-9816-6be514ab750c	3ccbfb80-52b6-4af0-9816-6be514ab750c
019e59e2-296a-77e3-8097-48a47729cdcf	Test Agin	Test agin 99	FIN	EVT	sdf	2026-05-24	120.00	adfds	sadf	sadf	PMA	2026-05-24 18:07:34.500103+06	2026-05-24 18:07:56.347694+06	3ccbfb80-52b6-4af0-9816-6be514ab750c	3ccbfb80-52b6-4af0-9816-6be514ab750c
019e59f9-0334-79e1-abcd-453ea42d7dc0	tst	test tt	FIN	COR	sdf	2026-05-24	120.00	sadf	sdf	sdf	PMA	2026-05-24 18:32:32.052398+06	\N	3ccbfb80-52b6-4af0-9816-6be514ab750c	\N
019e498c-18b2-7e8b-8811-bc03942e4bed	Test Title	Tes Name	OPS	COR	Test Event	2026-05-21	5000.00	test 	we will kno it later	NO	APR	2026-05-21 13:59:38.256046+06	\N	3ccbfb80-52b6-4af0-9816-6be514ab750c	\N
019e498e-df73-76d7-bd15-83e6c9389fc4	Small Fund99	Small Fund	MKT	COR	Test Event	2026-05-21	4000.00	test 	we will kno it later	NO	PFR	2026-05-21 14:02:40.625988+06	2026-05-23 14:21:28.294938+06	3ccbfb80-52b6-4af0-9816-6be514ab750c	\N
019e498e-e554-7d53-84bf-849f513a4773	Small Fund99	Small Fund99	HRM	EVT	Test Event 99	2026-05-30	3600.00	test 99	we will kno it later99	NO99	APR	2026-05-21 14:02:42.132455+06	2026-05-23 15:57:46.120666+06	3ccbfb80-52b6-4af0-9816-6be514ab750c	3ccbfb80-52b6-4af0-9816-6be514ab750c
019e498e-ecde-72fd-9dc8-a54a48454ac8	Mrs	Small Fund	ITC	STD	Test Event	2026-05-21	7500.00	test 	we will kno it later	NO	REJ	2026-05-21 14:02:44.061752+06	2026-05-23 15:49:59.720078+06	3ccbfb80-52b6-4af0-9816-6be514ab750c	3ccbfb80-52b6-4af0-9816-6be514ab750c
019e55e9-0991-753a-833e-548fc14b2408	DDDDD	DD	FIN	COR	dd	2026-05-23	120.00	sadf	sdf	sdf	CAN	2026-05-23 23:36:36.207205+06	\N	3ccbfb80-52b6-4af0-9816-6be514ab750c	\N
\.


--
-- TOC entry 5043 (class 0 OID 16499)
-- Dependencies: 222
-- Data for Name: sponsorship_types; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sponsorship_types (type_code, type_name, description, is_active) FROM stdin;
STD	Standard Sponsorship	Basic sponsorship package with limited benefits	t
PRM	Premium Sponsorship	Enhanced sponsorship with additional visibility and perks	t
VIP	VIP Sponsorship	Top-tier sponsorship with maximum benefits and priority access	t
COR	Corporate Sponsorship	Designed for corporate partners and organizations	t
EVT	Event Sponsorship	Sponsorship specifically for events and campaigns	t
\.


--
-- TOC entry 5040 (class 0 OID 16455)
-- Dependencies: 219
-- Data for Name: user_roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.user_roles (role_id, role_name, description, is_active) FROM stdin;
1	System Admin	View all requests and manage basic settings\n\n	t
2	Finance Admin	Final review and approval	t
3	Manager	Review and approve/reject request	t
4	Requestor	Submit sponsorship request	t
\.


--
-- TOC entry 5045 (class 0 OID 16530)
-- Dependencies: 224
-- Data for Name: workflow_histories; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.workflow_histories (workflow_id, sponsorship_id, notes, action_by, action_date) FROM stdin;
019e54b0-dda3-7355-95fe-0b05a459684a	019e498e-e554-7d53-84bf-849f513a4773	Status updated to PMA	76410011-0969-4c0f-b353-25ff8cd25341	2026-05-23 17:55:37.740458
019e54b1-8f30-7b4b-bd59-931d102a1b08	019e498e-e554-7d53-84bf-849f513a4773	Status updated to PMA	76410011-0969-4c0f-b353-25ff8cd25341	2026-05-23 17:56:23.215386
019e54b6-b6e6-7d04-bdc0-d21cd977a183	019e498e-e554-7d53-84bf-849f513a4773	Status updated to PFR	76410011-0969-4c0f-b353-25ff8cd25341	2026-05-23 18:02:01.062162
019e54b7-3db3-7375-abec-85833ca04d8a	019e498e-e554-7d53-84bf-849f513a4773	Status updated to APR	76410011-0969-4c0f-b353-25ff8cd25341	2026-05-23 18:02:35.571332
019e54f9-8335-70cf-b34c-1b117ea424ff	019e498e-df73-76d7-bd15-83e6c9389fc4	Status updated to PFR	76410011-0969-4c0f-b353-25ff8cd25341	2026-05-23 19:14:58.741149
019e54fa-7cab-72f1-bb0b-03c86d7ba59d	019e498e-e91d-78e5-80f4-825c563059a3	Status updated to PFR	76410011-0969-4c0f-b353-25ff8cd25341	2026-05-23 19:16:02.603739
019e54fc-6da5-707e-94ce-a8961e9bf0f8	019e498e-ecde-72fd-9dc8-a54a48454ac8	Status updated to REJ	76410011-0969-4c0f-b353-25ff8cd25341	2026-05-23 19:18:09.829432
019e55e9-0a1d-7174-9157-a8d4980ed9b6	019e55e9-0991-753a-833e-548fc14b2408	New	3ccbfb80-52b6-4af0-9816-6be514ab750c	2026-05-23 23:36:36.380115
019e55e9-61e7-7e20-a81d-827fafde05b8	019e55e9-61e5-7778-b530-0b56184df212	New	3ccbfb80-52b6-4af0-9816-6be514ab750c	2026-05-23 23:36:58.855336
019e5603-aba0-7796-b2c6-a5abfd91d938	019e498c-18b2-7e8b-8811-bc03942e4bed	Status updated to APR	90c7f968-fa6b-47de-b86a-da75c5d253f7	2026-05-24 00:05:41.640776
019e562a-7ef1-7d17-99ce-8bd4ffc360ce	019e55e9-0991-753a-833e-548fc14b2408	Status updated to CAN	3ccbfb80-52b6-4af0-9816-6be514ab750c	2026-05-24 00:48:06.128845
019e58d5-03d6-782a-891e-f39b58be1bf0	019e58d5-03b3-7acf-b3b2-4ef634ba3f6e	New	3ccbfb80-52b6-4af0-9816-6be514ab750c	2026-05-24 13:13:35.700441
019e5958-fcb5-7529-9af8-d5b285545630	019e498e-e91d-78e5-80f4-825c563059a3	Status updated to APR	90c7f968-fa6b-47de-b86a-da75c5d253f7	2026-05-24 15:37:44.629289
019e59e2-29a8-77ac-b3fe-047ea330b9a4	019e59e2-296a-77e3-8097-48a47729cdcf	New	3ccbfb80-52b6-4af0-9816-6be514ab750c	2026-05-24 18:07:34.566774
019e59f9-0336-7f92-a1f8-0a9a8d90b768	019e59f9-0334-79e1-abcd-453ea42d7dc0	New	3ccbfb80-52b6-4af0-9816-6be514ab750c	2026-05-24 18:32:32.054824
\.


--
-- TOC entry 5042 (class 0 OID 16482)
-- Dependencies: 221
-- Data for Name: workflow_status; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.workflow_status (status_code, status_name) FROM stdin;
DRA	Draft
PMA	Pending Manager Approval
PFR	Pending Finance Review
APR	Approved
REJ	Rejected
CAN	Cancelled
\.


-- Completed on 2026-05-24 19:39:06

--
-- PostgreSQL database dump complete
--

\unrestrict zUjmsAnLrASBvTVD8iphZy2daiTMYHMy0dSc3yWllxi3NRaLJJgXzxKFc1t7wzy

